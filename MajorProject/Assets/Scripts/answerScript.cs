using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class answerScript : MonoBehaviour
{
    public string answerString;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<TextMeshPro>().text = answerString;
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.GetComponent<question>().answer.ToString() == answerString){
            if(other.gameObject.GetComponent<question>().specialQuestion){
                gameManager.GetComponent<livesScript>().score += 3;
                gameManager.GetComponent<livesScript>().lives += 1;
            }
            else{
                gameManager.GetComponent<livesScript>().score += 1;
            }
        }
        else{
            gameManager.GetComponent<livesScript>().score -= 1;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
