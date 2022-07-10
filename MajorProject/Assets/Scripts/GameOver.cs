using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    //Declaring all the variables used in the code
    public TextMeshProUGUI GameOverText;
    public int highscore;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        //Getting the Score from the last game
        score = PlayerPrefs.GetInt("lastScore");
        //Getting the High Score from the last game
        highscore = PlayerPrefs.GetInt("highscore");
        //Displaying the Score and the High Score
        GameOverText.text = "Score: " + score.ToString() + "\nHigh Score: " + highscore.ToString();
    }

    //Function called on the button press to main menu
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
    //Function called on the button press to replay the game
    public void Replay(){
        SceneManager.LoadScene(1);
    }
}
