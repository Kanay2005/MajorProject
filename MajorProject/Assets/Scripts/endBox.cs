using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endBox : MonoBehaviour
{
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("yo mama");
        gameManager.GetComponent<livesScript>().lives -= 1;
        Destroy(col.gameObject);
    }
}
