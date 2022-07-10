using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyMenu : MonoBehaviour
{   
    public void Easy(){
        //Set the difficulty to easy
        PlayerPrefs.SetString("Difficulty", "Easy");
        //Go the main game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Medium(){
        //Set the difficulty to medium
        PlayerPrefs.SetString("Difficulty", "Medium");
        //Go the main game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Hard(){
        //Set the difficulty to hard
        PlayerPrefs.SetString("Difficulty", "Hard");
        //Go the main game scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
