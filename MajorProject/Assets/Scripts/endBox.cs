using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endBox : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject audioManager;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col) {
        audioManager.GetComponent<AudioManager>().Play("HitSound");
        gameManager.GetComponent<livesScript>().lives -= 1;
        Instantiate(explosion, new Vector2(col.transform.position.x*3/4 + gameObject.transform.position.x*1/4,col.transform.position.y), Quaternion.identity);
        Destroy(col.gameObject);
    }
}
