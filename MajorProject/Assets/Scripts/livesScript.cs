using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class livesScript : MonoBehaviour
{
    public int lives;
    public GameObject livesText;
    public TextMeshProUGUI scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
        livesText.GetComponent<TextMeshProUGUI>().text = "Lives: " + lives.ToString(); 
    }
}
