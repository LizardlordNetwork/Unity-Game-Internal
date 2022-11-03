using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class MainMenu : MonoBehaviour
{
    public bool ScoreReset = false;
    public GameObject ScoreScript;
    public int StartScore = 0;
    string FirstScene = "Level 1";
    void Start()
    {
        if (ScoreReset == false)
        {
            CreateHSFile();
            ScoreReset = true;
        }


    }
    public void PlayGame()
    {
        SceneManager.LoadScene(FirstScene);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    /*public void ScoreReset(bool ResetScore)
    {
        if (ResetScore == false)
        {
            //Writing the new highscore to the text document.
            using (StreamWriter writer = new StreamWriter("HighScores.txt"))
            {
                writer.WriteLine(StartScore);
            }
            //score = StartScore;
            //highScore = StartScore;
            ResetScore = true;
        }

    }*/
    public void CreateHSFile()
    {
        //Getting the path of the text document.
        string CheckPath = Application.dataPath + "/HighScores.txt";
        //If the file path doesn't exist.
        if (!File.Exists(CheckPath))
        {
            //Create a new file and reset the high score.
            File.WriteAllText(CheckPath, Convert.ToString(StartScore));

        }
    }
}
