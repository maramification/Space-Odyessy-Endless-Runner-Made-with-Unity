
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    

    public AudioSource audioSrc;
    public AudioSource coinAudioSrc;
    public AudioSource formAudioSrc;
    public AudioSource powerUpAudioSrc;
    public AudioSource obstacleAudioSrc;
    public AudioSource gamingErrorAudioSrc;


    public AudioClip pauseMenuAudio;
    public AudioClip gameOverAudio;
    public AudioClip coinAudio;
    public AudioClip formAudio;
    public AudioClip powerUpAudio;
    public AudioClip obstacleAudio;
    public AudioClip gamingErrorAudio;
    
    public GameObject gameOver;
    bool alive = true;

    public GameObject pauseMenu;
    public static bool isPaused;

    public bool multiplier = false;
    public bool greenForm = false;

    public bool shield = false;
    public bool blueForm = false;


    public bool nuke = false;
    public bool redForm = false;


    //cheats
    public bool invincible = false;



    public float moveSpeed = 5;
    [SerializeField] Rigidbody rb;
    float horizontalInput;
    [SerializeField] float horizontalSpeed = 4;
    public float speedIncreasePerPoint = 0.1f;
    GameManager gameManager;


    public bool isGameOver;
    



    private void Start()
    {
        pauseMenu.SetActive(false);
        gameOver.SetActive(false);
    }

    private void FixedUpdate()
    {

        if (!alive) return;
        Vector3 forwardMove = transform.forward * moveSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * horizontalSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);                                                                                                           
    }


    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");


        gameManager = GameObject.FindObjectOfType<GameManager>();
        

       


        if (Input.GetKeyDown(KeyCode.J) && (gameManager.redScore == 5))
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            GameManager.inst.DecrementRedScore();
            redForm = true;
            playformAudio();
            greenForm = false;
            blueForm = false;
            multiplier = false;
            shield = false;


        }


        if (Input.GetKeyDown(KeyCode.J) && (gameManager.redScore <= 4) && (!redForm) )
        {
           playGamingErrorAudio();
        }


        if (Input.GetKeyDown(KeyCode.K) && (gameManager.greenScore == 5))
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
            GameManager.inst.DecrementGreenScore();
            greenForm = true;
            playformAudio();
            blueForm = false;
            redForm = false;
            nuke = false;
            shield = false;
       
        }


        if (Input.GetKeyDown(KeyCode.K) && (gameManager.greenScore <= 4) && (!greenForm))
        {
            playGamingErrorAudio();
        }




        if (Input.GetKeyDown(KeyCode.L) && (gameManager.blueScore == 5)) {
            GetComponent<MeshRenderer>().material.color = Color.blue;
            GameManager.inst.DecrementBlueScore();
            blueForm = true;
            playformAudio();
            redForm = false;
            greenForm = false;
            nuke = false;
            multiplier = false;
            
        }


        if (Input.GetKeyDown(KeyCode.L) && (gameManager.blueScore <= 4) && (!blueForm))
        {
            playGamingErrorAudio();

        }







        if (Input.GetKeyDown(KeyCode.Space) && (gameManager.redScore > 0) && (!nuke) && (redForm))
        {
            nuke = true;
            playPowerUpAudio();
            multiplier = false;
            shield = false;
            greenForm = false;
            blueForm = false;
            GameManager.inst.DecrementRedScore();

            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (GameObject c in cubes)
            {
                Destroy(c);
            }
            nuke = false;

        }


        if (Input.GetKeyDown(KeyCode.Space) && (gameManager.greenScore > 0) && (!multiplier) && (greenForm))
        {
            multiplier = true;
            playPowerUpAudio();
            nuke = false;
            shield = false;
            redForm = false;
            blueForm = false;
            GameManager.inst.DecrementGreenScore();
        }



        if (Input.GetKeyDown(KeyCode.Space) && (gameManager.blueScore > 0) && (!shield) && (blueForm))
        {
            shield = true;
            playPowerUpAudio();
            nuke = false;
            multiplier = false;
            redForm = false;
            greenForm = false;
            GameManager.inst.DecrementBlueScore();
        }


        if ((Input.GetKeyDown(KeyCode.Space)  && !(redForm || greenForm || blueForm))) {
            playGamingErrorAudio();
        }


        if (Input.GetKeyDown(KeyCode.U))
        {
            if (!invincible)
            {
                invincible = true;
            }

            else
            {
                invincible = false;
            }
           
        }


        if (Input.GetKeyDown(KeyCode.I))
        {
            GameManager.inst.IncrementRedScore();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            GameManager.inst.IncrementGreenScore();
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.inst.IncrementBlueScore();
        }






        if ((gameManager.redScore == 0) && (redForm))
        {
            //nuke = false;
            redForm = false;
            GetComponent<MeshRenderer>().material.color = Color.white;
            playformAudio();

        }

        if ((gameManager.greenScore == 0) && (greenForm))
        {
            multiplier = false;
            greenForm = false;
            GetComponent<MeshRenderer>().material.color = Color.white;
            playformAudio();

        }

        if ((gameManager.blueScore == 0) && (blueForm))
        {
            shield = false;
            blueForm = false;
            GetComponent<MeshRenderer>().material.color = Color.white;
            playformAudio();

        }


        if (Input.GetKeyDown(KeyCode.Escape))
        {

            

            if (isPaused)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
                BGGame.instance.GetComponent<AudioSource>().Pause();
            }
            
        }

    }

    public void Die()
    {
        gameOver.SetActive(true);
        playGameOverMusic();
        BGGame.instance.GetComponent<AudioSource>().Pause();
        alive = false;
    }

   


    public void RestartGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    public void PauseGame()
    {

        if (!isGameOver)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            playPauseMenuMusic();
            isPaused = true;
        }
      
    }


    public void ResumeGame()
    {
        BGGame.instance.GetComponent<AudioSource>().Play();
        audioSrc.Stop();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }


    public void goToMainMenu()
    {
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }


    public void playPauseMenuMusic()
    {
        audioSrc.clip = pauseMenuAudio;
            audioSrc.Play();
    }


    public void playGameOverMusic()
    {
        audioSrc.clip = gameOverAudio;
        audioSrc.Play();
    }

    public void playCoinAudio()
    {
        coinAudioSrc.clip = coinAudio;
        coinAudioSrc.Play();
    }

    public void playformAudio()
    {
        formAudioSrc.clip = formAudio;
        formAudioSrc.Play();
    }

    public void playPowerUpAudio()
    {
        powerUpAudioSrc.clip = powerUpAudio;
        powerUpAudioSrc.Play();
    }


    public void playObstacleAudio()
    {
        obstacleAudioSrc.clip = obstacleAudio;
        obstacleAudioSrc.Play();
    }

    public void playGamingErrorAudio()
    {
        gamingErrorAudioSrc.clip = gamingErrorAudio;
        gamingErrorAudioSrc.Play(); 
    }

}
