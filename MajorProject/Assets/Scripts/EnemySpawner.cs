using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    private int time;
    private string[] operations = {"+","-","*","/"};
    private int operation1;
    private int operation2;
    private int number1;
    private int number2;
    private int number3;
    private string question;
    private double answer;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public Transform enemyTransform;
    public GameObject enemyPrefab;
    public Rigidbody2D enemyRb;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Count", 1, 1);
        Invoke("Spawn", 1);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = enemyTransform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = enemyTransform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(){
        number1 = Random.Range(0,Mathf.RoundToInt(Mathf.Sqrt(time)));
        number2 = Random.Range(0,Mathf.RoundToInt(Mathf.Sqrt(time)));
        number3 = Random.Range(0,Mathf.RoundToInt(Mathf.Sqrt(time)));
        operation1 = Random.Range(0,3);
        operation2 = Random.Range(0,3);
        question = number1.ToString() + operations[operation1] + number2.ToString() + operations[operation2] + number3.ToString();
        ExpressionEvaluator.Evaluate(question, out int answer);
        GameObject questionObject = Instantiate(enemyPrefab, new Vector3(10, Random.Range(screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight), 0), Quaternion.identity);
        questionObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-3.0f-Mathf.Sqrt((float)time/10f),0f);
        questionObject.GetComponent<question>().questionString = question;
        questionObject.GetComponent<question>().answer = answer;
        questionObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<TextMeshPro>().text = question;
        Invoke("Spawn", 3*Mathf.Exp(time*-1/60));
    }
    public void Count(){
        time++;
    }

}
