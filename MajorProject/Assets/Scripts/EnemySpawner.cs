using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private int answer;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public Transform enemyTransform;
    public GameObject enemyPrefab;
    public Rigidbody2D enemyRb;
    public bool specialQuestion;
    public int tempNumber;

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
        if(operation1 == 2){
            number1 = Random.Range(1,Mathf.RoundToInt(randomInt()/3));
        }
        else{
            number1 = Random.Range(1,randomInt());
        }
        number1 = Random.Range(1,randomInt());
        operation1 = Random.Range(0,4);
        if(operation1 == 0){
            number2 = Random.Range(1,randomInt());
        }
        if(operation1 == 1){
            number2 = Random.Range(1,number1+1);
        }
        if(operation1 == 2){
            number2 = Random.Range(1,Mathf.RoundToInt(randomInt()/3));
        }
        if(operation1 == 3){
            number2 = Factors(number1)[Random.Range(0,Factors(number1).Count)];
        }
        if(Random.Range(0,10) <9){
            specialQuestion = false;
        }
        else{
            specialQuestion = true;
        }
        if(specialQuestion){
            tempNumber = Evaluate(number1 + operations[operation1] + number2);
            operation2 = Random.Range(2,4);
            if(operation2 == 2){
                number3 = Random.Range(1,4);
            }
            if(operation2 == 3){
                number3 = Factors(number2)[Random.Range(0,Factors(number2).Count)];
            }
            question = number1.ToString() + operations[operation1] + number2.ToString() + operations[operation2] + number3.ToString();
        }
        else{
            question = number1.ToString() + operations[operation1] + number2.ToString();
        }
        
        answer = Evaluate(question);
        GameObject questionObject = Instantiate(enemyPrefab, new Vector3(10, Random.Range(screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight - 1f), 0), Quaternion.identity);
        questionObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f-Mathf.Sqrt((float)time/60f),0f);
        question = question.Replace("+", " + ").Replace("-"," - ").Replace("*", " × ").Replace("/", " ÷ ");
        questionObject.GetComponent<question>().questionString = question;
        questionObject.GetComponent<question>().specialQuestion = specialQuestion;
        questionObject.GetComponent<question>().answer = answer;
        questionObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<TextMeshPro>().text = question;
        if(specialQuestion){
            questionObject.GetComponent<SpriteRenderer>().color = new Color(255,255,0);
        }
        if(time < 18){
            Invoke("Spawn", 4*Mathf.Exp((float)time*-1/60));
        }
        else{
            Invoke("Spawn", 3);
        }
    }
    public void Count(){
        time++;
    }
    public List<int> Factors(int input){
        List<int> factors = new List<int>();
        for(int i = 1; i <= input; i++){
            if(input%i == 0){
                factors.Add(i);
            }
        }
        return factors;
    }

    public static int Evaluate(string expression)  
       {  
           System.Data.DataTable table = new System.Data.DataTable();  
           table.Columns.Add("expression", string.Empty.GetType(), expression);  
           System.Data.DataRow row = table.NewRow();  
           table.Rows.Add(row);  
           return int.Parse((string)row["expression"]);  
       }
    
    public int randomInt(){
        return 5+2*Mathf.RoundToInt(Mathf.Sqrt(time));
    }


}
