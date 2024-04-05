
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] float turnSpeed = 90f;
    PlayerMove playerMove;
    
 


    private void OnTriggerEnter(Collider other)
    {
        playerMove = GameObject.FindObjectOfType<PlayerMove>();


        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Player")
        {
            return;
        }


        if (gameObject.CompareTag("Blue"))
        {
           
            if (playerMove.multiplier)
            {
                GameManager.inst.GreenPowerBlueOrb();
                playerMove.multiplier = false;
            }
            
            else if (playerMove.blueForm)
            {
                GameManager.inst.IncrementScoreForm();
            }

            else
            {
                GameManager.inst.IncrementBlueScore();
            }
           
        }





        else if (gameObject.CompareTag("Red"))
        {
            
            if (playerMove.redForm)
            {
                GameManager.inst.IncrementScoreForm();
            }

            else if (playerMove.multiplier)
            {
                GameManager.inst.GreenPowerRedOrb();
                playerMove.multiplier = false;
            }

            else
            {
                GameManager.inst.IncrementRedScore();
            }

        }




        else if (gameObject.CompareTag("Green"))
        {
            
            if (playerMove.multiplier)
            {
                
                GameManager.inst.GreenFormGreenPower();
                playerMove.multiplier = false;
            }

            else if ((playerMove.greenForm) && (!playerMove.multiplier))
            {
                GameManager.inst.IncrementScoreForm();
            }

            else
            {
               
                GameManager.inst.IncrementGreenScore();
            }
           
        }

        GameManager.inst.IncrementScore();
        Destroy(gameObject);
        playerMove.playCoinAudio();
     


       



    }



    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }


   
}
