using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class answerScript : MonoBehaviour
{
    public string answerString;
    public GameObject gameManager;
    public GameObject audioManager;
    public GameObject explosion;
    public GameObject reflect;
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
            Instantiate(explosion, (other.transform.position + gameObject.transform.position)/2, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else{
            GetComponent<Rigidbody2D>().velocity = -GetComponent<Rigidbody2D>().velocity;
            transform.localScale = new Vector2(-transform.localScale.y,transform.localScale.y);
            transform.GetChild(0).transform.localScale = new Vector2(-transform.GetChild(0).transform.localScale.y,transform.GetChild(0).transform.localScale.y);
            audioManager.GetComponent<AudioManager>().Play("Fail");
            Instantiate(reflect, gameObject.transform.position, Quaternion.identity);
        }
        } 
    }
}
