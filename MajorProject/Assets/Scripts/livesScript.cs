using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class livesScript : MonoBehaviour
{
    public int lives;
    public GameObject livesText;
    public TextMeshProUGUI scoreText;
    public int score;
    public int highscore;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore");

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        livesText.GetComponent<TextMeshProUGUI>().text = "Lives: " + lives.ToString(); 
        if(score > highscore){
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
        }
        PlayerPrefs.SetInt("lastScore", score);

        if(lives<=0){
            SceneManager.LoadScene(2);
        }
    }
}
