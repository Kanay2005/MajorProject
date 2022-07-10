using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endBox : MonoBehaviour
{
    //Declaring all the variables used in the code
    public GameObject gameManager;
    public GameObject audioManager;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        //Finding the Audio Manager
        audioManager = GameObject.Find("AudioManager");
    }

    //Running when a collision occurs
    void OnTriggerEnter2D(Collider2D col) {
        //Playing the hit sound on collision
        audioManager.GetComponent<AudioManager>().Play("HitSound");
        //Removing a life on collision
        gameManager.GetComponent<livesScript>().lives -= 1;
        //Playing the hit animation on collision
        Instantiate(explosion, new Vector2(col.transform.position.x*3/4 + gameObject.transform.position.x*1/4,col.transform.position.y), Quaternion.identity);
        //Destroying the game object after collision
        Destroy(col.gameObject);
    }
}
