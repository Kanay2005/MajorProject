using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }
    public void Resume(){
        GameIsPaused = false;
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1;
    }
    public void Pause(){
        GameIsPaused = true;
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0;
    }
    public void ReturnMain(){
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
