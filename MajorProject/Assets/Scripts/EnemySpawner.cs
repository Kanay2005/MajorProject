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
    string Difficulty;
    int valueDiffIncrease;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Count", 1, 1);
        Invoke("Spawn", 1);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = enemyTransform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = enemyTransform.GetComponent<SpriteRenderer>().bounds.extents.y;

        Difficulty = PlayerPrefs.GetString("Difficulty");

        if(Difficulty == "Easy"){
            valueDiffIncrease = 3;
        }

        if(Difficulty == "Medium"){
            valueDiffIncrease = 4;
        }

        if(Difficulty == "Hard"){
            valueDiffIncrease = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(){
        operation1 = Random.Range(0,4);
        number1 = randomInt(operation1);
        if(operation1 == 1){
            number2 = Random.Range(1,number1+1);
        }
        else{
            if(operation1 == 3){
            number2 = Factors(number1)[Random.Range(0,Factors(number1).Count)];
            }
            else{
                number2 = randomInt(operation1);
            }
        }
        
        if(Random.Range(0,10) < 9){
            specialQuestion = false;
            question = number1.ToString() + operations[operation1] + number2.ToString();
        }
        else{
            if(operation1 != 1){
                specialQuestion = true;
                
                if(operation1 == 2){
                    number3 = Random.Range(1,valueDiffIncrease);
                }
                else{
                    number3 = randomInt(2);
                    if(operation1 ==0){
                        number2 = Mathf.RoundToInt(number2/3);
                    }
                }
                question = number1.ToString() + operations[operation1] + number2.ToString() + operations[2] + number3.ToString();
            }
            else{
                question = number1.ToString() + operations[operation1] + number2.ToString();
            }
        }
        print(question);
        answer = Evaluate(question);
        GameObject questionObject = Instantiate(enemyPrefab, new Vector3(10, Random.Range(screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight - 1f), 0), Quaternion.identity);
        questionObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f-Mathf.Sqrt((float)time*(float)valueDiffIncrease*(float)valueDiffIncrease/(25f*60f)),0f);
        question = question.Replace("+", " + ").Replace("-"," - ").Replace("*", " × ").Replace("/", " ÷ ");
        questionObject.GetComponent<question>().questionString = question;
        questionObject.GetComponent<question>().specialQuestion = specialQuestion;
        questionObject.GetComponent<question>().answer = answer;
        questionObject.GetComponent<Transform>().GetChild(0).gameObject.GetComponent<TextMeshPro>().text = question;
        if(specialQuestion){
            questionObject.GetComponent<SpriteRenderer>().color = new Color(0,255,0);
        }
        if((12-valueDiffIncrease)*Mathf.Exp((float)time*-1/60) > 8-valueDiffIncrease){
            Invoke("Spawn", (12-valueDiffIncrease)*Mathf.Exp((float)time*-1/60));
        }
        else{
            Invoke("Spawn", 8-valueDiffIncrease);
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
    
    public int randomInt(int operation){
        if(operation == 0 | operation == 1 | operation == 3){
            return Random.Range(Mathf.RoundToInt((float)(valueDiffIncrease-1)*Mathf.Sqrt(time)),Mathf.RoundToInt(Mathf.Sqrt(valueDiffIncrease*valueDiffIncrease*time + 25)));
        }
        else{
            return Random.Range(Mathf.RoundToInt(((float)(valueDiffIncrease-1)*Mathf.Sqrt(time))/3),Mathf.RoundToInt((Mathf.Sqrt(valueDiffIncrease*valueDiffIncrease*time + 25)))/3);
        }
    }


}
