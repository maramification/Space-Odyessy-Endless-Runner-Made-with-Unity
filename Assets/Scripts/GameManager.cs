using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    int score;
    public int redScore;
    public int blueScore;
    public int greenScore;
    public static GameManager inst;
    public TMP_Text scoreText;
    public TMP_Text redScoreText;
    public TMP_Text blueScoreText;
    public TMP_Text greenScoreText;
    public TMP_Text finalScoreText;
    [SerializeField] PlayerMove playerMovement;
    public PlayerMove playerMove;

    public void IncrementScore()
    {

        score++;
        scoreText.text = "Score: " + score;
        finalScoreText.text = "FINAL SCORE: " + score;

        // playerMovement.moveSpeed += playerMovement.speedIncreasePerPoint;
    }



    public void IncrementScoreForm()
    {

        score += 1;
        scoreText.text = "Score: " + score;
        finalScoreText.text = "FINAL SCORE: " + score;

       //  playerMovement.moveSpeed += playerMovement.speedIncreasePerPoint;
    }



    public void IncrementRedScore()
    {

        if (redScore < 5)
        {
            redScore++;
        }

        redScoreText.text = "Red: " + redScore;
    }



    public void DecrementRedScore()
    {
        redScore--;

        redScoreText.text = "Red: " + redScore;
    }



    public void IncrementBlueScore()
    {

        if (blueScore < 5)
        {
            blueScore++;
        }
      
        blueScoreText.text = "Blue: " + blueScore;
    }



    public void DecrementBlueScore()
    {
        blueScore--;

        blueScoreText.text = "Blue: " + blueScore;
    }



    public void IncrementGreenScore()
    {

        if (greenScore < 5)
        {
            greenScore++;
        }

        greenScoreText.text = "Green: " + greenScore;
    }





    public void GreenFormGreenPower()
    {
            score += 9; //i increase the score by one in all ways upon orb collection
            scoreText.text = "Score: " + score;
            finalScoreText.text = "FINAL SCORE: " + score;

    }



    public void GreenPowerRedOrb()
    {
        score += 4; //i increase the score by one in all ways upon orb collection
        scoreText.text = "Score: " + score;
        finalScoreText.text = "FINAL SCORE: " + score;


        if (redScore < 4)
        {
            redScore += 2;
            redScoreText.text = "Red: " + redScore;
        }


        else if (redScore == 4)
        {
            redScore += 1;
            redScoreText.text = "Red: " + redScore;
        }
    }


    public void GreenPowerBlueOrb()
    {
        score += 4; //i increase the score by one in all ways upon orb collection
        scoreText.text = "Score: " + score;
        finalScoreText.text = "FINAL SCORE: " + score;


        if (blueScore < 4)
        {
            blueScore += 2;
            blueScoreText.text = "Blue: " + blueScore;
        }


        else if (blueScore == 4)
        {
            blueScore += 1;
            blueScoreText.text = "Blue: " + blueScore;
        }
    }



    public void DecrementGreenScore()
    {
        greenScore--;

       greenScoreText.text = "Green: " + greenScore;
    }



    private void Awake()
    {
        inst = this;
    }

    public void Zeroify()
    {
        scoreText.text = "";
        redScoreText.text = "";
        greenScoreText.text = "";
        blueScoreText.text = "";
    }

}
