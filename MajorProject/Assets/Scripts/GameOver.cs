using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI GameOverText;
    public int highscore;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("lastScore");
        highscore = PlayerPrefs.GetInt("highscore");
        GameOverText.text = "Score: " + score.ToString() + "\nHigh Score: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
    public void Replay(){
        SceneManager.LoadScene(1);
    }
}
