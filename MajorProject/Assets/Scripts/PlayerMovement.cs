using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    //Declaring all the variables used in the code
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public Vector2 speed = new Vector2(0,20);
    public TextMeshPro answerText;
    public string answerString = "";
    public GameObject bullet;
    public Animator playerAnimator;
    // Start is called before the first frame update
    void Awake()
    {
        //Getting the rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }
    void Start() {
        //Finding the edges of the screen
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Getting the vertical input 
        float inputY = Input.GetAxis("Vertical");
        //Setting the player into movement according to the input
        Vector3 movement = new Vector3(0, speed.y * inputY, 0);
        if(movement.y > 0){
            //Setting the animation into moveUp
            playerAnimator.SetBool("moveUp", true);
            playerAnimator.SetBool("moveDown", false);
        }
        if(movement.y < 0){
            //Setting the animation into moveDown
            playerAnimator.SetBool("moveUp", false);
            playerAnimator.SetBool("moveDown", true);
        }
        if(movement.y == 0){
            //Setting the animation to neutral
            playerAnimator.SetBool("moveDown", false);
            playerAnimator.SetBool("moveUp", false);
        }
        //making it so that the movement doesnt change depending on the framerate
        movement *= Time.deltaTime;
        //Applying the movement to the game object
        transform.Translate(movement);
        //Adding 1 to the answerString if the number key is pressed
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            answerString += "1";
        }
        //Adding 2 to the answerString if the number key is pressed
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            answerString += "2";
        }
        //Adding 3 to the answerString if the number key is pressed
        if(Input.GetKeyDown(KeyCode.Alpha3)){
            answerString += "3";
        }
        //Adding 4 to the answerString if the number key is pressed
        if(Input.GetKeyDown(KeyCode.Alpha4)){
            answerString += "4";
        }
        //Adding 5 to the answerString if the number key is pressed
        if(Input.GetKeyDown(KeyCode.Alpha5)){
            answerString += "5";
        }
        //Adding 6 to the answerString if the number key is pressed
        if(Input.GetKeyDown(KeyCode.Alpha6)){
            answerString += "6";
        }
        //Adding 7 to the answerString if the number key is pressed
        if(Input.GetKeyDown(KeyCode.Alpha7)){
            answerString += "7";
        }
        //Adding 8 to the answerString if the number key is pressed
        if(Input.GetKeyDown(KeyCode.Alpha8)){
            answerString += "8";
        }
        //Adding 9 to the answerString if the number key is pressed
        if(Input.GetKeyDown(KeyCode.Alpha9)){
            answerString += "9";
        }
        //Adding 0 to the answerString if the number key is pressed
        if(Input.GetKeyDown(KeyCode.Alpha0)){
            answerString += "0";
        }
        //Removing the last character of answerString if backspace is pressed
        if(Input.GetKeyDown(KeyCode.Backspace)){
            //Checking if the string is not empty
            if(answerString != ""){
                answerString = answerString.Remove(answerString.Length-1);
            }
        }
        //Shooting the answer if space or enter is pressed
        if(Input.GetKeyDown(KeyCode.Space)|Input.GetKeyDown(KeyCode.Return)){
            //Checking if the answer is not empty
            if(answerString != ""){
                //Creating a bullet object
                GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
                //Adding velocity to the object
                bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(10f,0f);
                //Adding the answer to the object
                bulletClone.GetComponent<answerScript>().answerString = answerString;
                answerString = "";
                //Destroying the object if it doesnt collide after 5 seconds
                Destroy(bulletClone, 5);
            }
        }
        //Setting the text on the answer object to the answer inputted
        answerText.text = answerString;
    }
    
    void LateUpdate() {
        //Making it so that the player can only stay within the bounds of the screen
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
