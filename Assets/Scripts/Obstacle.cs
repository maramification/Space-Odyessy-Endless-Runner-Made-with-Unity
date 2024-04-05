using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    PlayerMove playerMovement;
    GameManager gameManager;
    BoxCollider obstacleCollider;
    

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMove>();
    }

    private void OnCollisionEnter(Collision collision)
    {  
        
        obstacleCollider = gameObject.GetComponent<BoxCollider>();

        if (playerMovement.invincible)
        {
           
            obstacleCollider.enabled = false;
        }

        else
        {
            
            obstacleCollider.enabled = true;






            if (collision.gameObject.name == "Player")
            {


                gameManager = GameObject.FindObjectOfType<GameManager>();


                playerMovement.playObstacleAudio();



                if ((!playerMovement.shield) && (!playerMovement.blueForm) && (!playerMovement.greenForm) && (!playerMovement.redForm))
                {
                    
                    playerMovement.Die();
                    playerMovement.isGameOver = true;
                    GameManager.inst.Zeroify();
                }

                else if (playerMovement.shield)
                {


                    playerMovement.shield = false;
                    Destroy(gameObject);
                }

                else
                {

                    playerMovement.greenForm = false;
                    playerMovement.blueForm = false;
                    playerMovement.redForm = false;
                    playerMovement.GetComponent<MeshRenderer>().material.color = Color.white;


                    playerMovement.playformAudio();



                    Destroy(gameObject);

                }

            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
