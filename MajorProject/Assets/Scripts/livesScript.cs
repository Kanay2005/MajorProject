using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class livesScript : MonoBehaviour
{
    public int lives;
    public GameObject livesText;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        livesText.GetComponent<TextMeshProUGUI>().text = "Lives: " + lives.ToString(); 
    }
}
