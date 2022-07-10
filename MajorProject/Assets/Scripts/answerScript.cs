using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class answerScript : MonoBehaviour
{
    //Declaring all the variables used in the code
    public string answerString;
    public GameObject gameManager;
    public GameObject audioManager;
    public GameObject explosion;
    public GameObject reflect;
    // Start is called before the first frame update
    void Start()
    {
        //Getting the answer that was inputted by the user and then setting the text to that answer
        GetComponentInChildren<TextMeshPro>().text = answerString;
        //Finding the different gameobjects needed for later
        gameManager = GameObject.Find("GameManager");
        audioManager = GameObject.Find("AudioManager");
        GameObject other = GameObject.FindGameObjectWithTag("answer");
        //Making it so it doesnt collide with other answers
        Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other){
        //Checking is the collision is from a question
        if(other.tag == "question"){
            //If to check if the answer was correct
            if(other.gameObject.GetComponent<question>().answer.ToString() == answerString){
                //if the question was of the special kind
                if(other.gameObject.GetComponent<question>().specialQuestion){
                    audioManager.GetComponent<AudioManager>().Play("HitSound");
                    //provide score and lives if the answer was right
                    gameManager.GetComponent<livesScript>().score += 3;
                    gameManager.GetComponent<livesScript>().lives += 1;
                }
                //if the question was just a regular one
                else{
                    //provide score and lives if the answer was right
                    gameManager.GetComponent<livesScript>().score += 1;
                    audioManager.GetComponent<AudioManager>().Play("HitSound");
                }
            //deleting the answer and creating an explosion animation
            Instantiate(explosion, (other.transform.position + gameObject.transform.position)/2, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        //If the answer was wrong
        else{
            //Reflecting the answer back
            GetComponent<Rigidbody2D>().velocity = -GetComponent<Rigidbody2D>().velocity;
            transform.localScale = new Vector2(-transform.localScale.y,transform.localScale.y);
            transform.GetChild(0).transform.localScale = new Vector2(-transform.GetChild(0).transform.localScale.y,transform.GetChild(0).transform.localScale.y);
            //Playing the reflect sound effect
            audioManager.GetComponent<AudioManager>().Play("Fail");
            //Playing the reflect animation at the point of reflection
            Instantiate(reflect, gameObject.transform.position, Quaternion.identity);
        }
        } 
    }
}
