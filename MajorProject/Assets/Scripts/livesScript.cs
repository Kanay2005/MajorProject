using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class livesScript : MonoBehaviour
{
    //Declaring all the variables used in the code
    public int lives;
    public GameObject livesText;
    public TextMeshProUGUI scoreText;
    public int score;
    public int highscore;
    // Start is called before the first frame update
    void Start()
    {
        //Setting the default values for lives and score
        lives = 3;
        score = 0;
        //Getting the previous high score
        highscore = PlayerPrefs.GetInt("highscore");

    }

    // Update is called once per frame
    void Update()
    {
        //Displaying the score on the screen
        scoreText.text = "Score: " + score;
        //Displaying the lives on the screen
        livesText.GetComponent<TextMeshProUGUI>().text = "Lives: " + lives.ToString(); 
        //Checking if the current score is higher than the highscore
        if(score > highscore){
            //If the Score is higher than the high score then make the current score the high score and save it
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        //Saving the current score of the game
        PlayerPrefs.SetInt("lastScore", score);

        if(lives<=0){
            //If the lives run out then go to the game over screen
            SceneManager.LoadScene(2);
        }
    }
}
