using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    //Declaring all the variables used in the code
    public bool GameIsPaused = false;
    public GameObject pauseMenuUi;

    // Update is called once per frame
    void Update()
    {
        //Checking if the escape key was pressed
        if(Input.GetKeyDown(KeyCode.Escape)){
            //Checking if the game is paused
            if(GameIsPaused){
                //Resuming the game if the game was paused
                Resume();
            }
            else{
                //Pausing the game if the games wasnt paused
                Pause();
            }
        }
    }
    //Function for resuming the game
    public void Resume(){
        //Setting GameIsPaused to false
        GameIsPaused = false;
        //Removing the Pause Menu
        pauseMenuUi.SetActive(false);
        //Setting time back to normal
        Time.timeScale = 1;
    }
    //Function for pausing the game
    public void Pause(){
        //Setting GameIsPaused to true
        GameIsPaused = true;
        //Showing the Pause Menu
        pauseMenuUi.SetActive(true);
        //Pausing the time
        Time.timeScale = 0;
    }
    //Function to return to the main menu
    public void ReturnMain(){
        //Setting time back to normal
        Time.timeScale = 1;
        //Loading the main menu
        SceneManager.LoadScene(0);
    }
}
