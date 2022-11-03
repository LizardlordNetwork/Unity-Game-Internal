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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        string CheckPath = Application.dataPath + "/HighScores.txt";
        if (!File.Exists(CheckPath))
        {
            File.WriteAllText(CheckPath, Convert.ToString(StartScore));

        }
    }
}
