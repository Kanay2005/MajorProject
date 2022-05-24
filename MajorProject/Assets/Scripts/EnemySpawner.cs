using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int time;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Count", 1, 1);
        Invoke("Spawn", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(){
        Debug.Log("enemy spawn");
        Invoke("Spawn", 2*Mathf.Exp(time*-1/30));
    }
    public void Count(){
        time++;
    }

}
