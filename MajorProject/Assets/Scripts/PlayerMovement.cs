using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public Vector2 speed = new Vector2(0,20);
    public TextMeshPro answerText;
    public string answerString = "";
    public GameObject bullet;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        float inputY = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, speed.y * inputY, 0);
        movement *= Time.deltaTime;
        transform.Translate(movement);
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            answerString += "1";
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            answerString += "2";
        }
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            answerString += "3";
        }
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            answerString += "4";
        }
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            answerString += "5";
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)){
            answerString += "6";
        }
        if(Input.GetKeyDown(KeyCode.Alpha7)){
            answerString += "7";
        }
        if(Input.GetKeyDown(KeyCode.Alpha8)){
            answerString += "8";
        }
        if(Input.GetKeyDown(KeyCode.Alpha9)){
            answerString += "9";
        }
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            answerString += "0";
        }
        if(Input.GetKeyDown(KeyCode.Backspace)){
            if(answerString != ""){
                answerString = answerString.Remove(answerString.Length-1);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)|Input.GetKeyDown(KeyCode.Return)){
            if(answerString != ""){
                GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
                bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(10f,0f);
                bulletClone.GetComponent<answerScript>().answerString = answerString;
                answerString = "";
                Destroy(bulletClone, 5);
            }
        }
        answerText.text = answerString;
    }
    
    void LateUpdate() {
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
