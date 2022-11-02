using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    float TimeStopped = 0f;
    float NormalRate = 1f;
    string MenuScene = "Menu";

    // Start is called before the first frame update
    void Start()
    {
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        //If the space key is pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If game isn't paused.
            if (GameisPaused == false)
            {
                //Pause the game.
                Pause();
            }
            else
            {
                //Resume the game
                Resume();
            }
        }


    }
    public void Resume()
    {
        //Disabling the pause menu.
        pauseMenuUI.SetActive(false);
        //Setting time to run at a normal speed.
        Time.timeScale = NormalRate;
        //Setting that the game is paused to flase.
        GameisPaused = false;
    }
    void Pause()
    {
        //Enabling the pause menu.
        pauseMenuUI.SetActive(true);
        //Stoping time while pause menu is active.
        Time.timeScale = TimeStopped;
        //Setting that the game is paused to true.
        GameisPaused = true;
    }

    public void LoadMenu()
    {
        //Loads the Menu when the method is called.
        SceneManager.LoadScene(MenuScene);
    }

    public void QuitGame()
    {
        //Quits the application.
        Application.Quit();
    }
}
