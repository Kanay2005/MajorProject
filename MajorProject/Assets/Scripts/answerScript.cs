using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class answerScript : MonoBehaviour
{
    public string answerString;
    public GameObject gameManager;
    public GameObject audioManager;
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<TextMeshPro>().text = answerString;
        gameManager = GameObject.Find("GameManager");
        audioManager = GameObject.Find("AudioManager");
        GameObject other = GameObject.FindGameObjectWithTag("answer");
        Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "question"){
            if(other.gameObject.GetComponent<question>().answer.ToString() == answerString){
            if(other.gameObject.GetComponent<question>().specialQuestion){
                audioManager.GetComponent<AudioManager>().Play("HitSound");
                gameManager.GetComponent<livesScript>().score += 3;
                gameManager.GetComponent<livesScript>().lives += 1;
            }
            else{
                gameManager.GetComponent<livesScript>().score += 1;
                audioManager.GetComponent<AudioManager>().Play("HitSound");
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else{
            GetComponent<Rigidbody2D>().velocity = -GetComponent<Rigidbody2D>().velocity;
            audioManager.GetComponent<AudioManager>().Play("Fail");
        }
        } 
    }
}
