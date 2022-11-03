using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class Score_Counter : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScoreText;
    public static int score;

    //List of scores.
    List<int> Scores = new List<int>();

    //The high score.
    public int highScore;
    public int StartScore = 0;
    public int maxScore = 480;
    public GameObject WinScreen;

    //The line read by the stream reader.
    string streamreaderline;

    int CollectibleScore = 10;

    public bool ResetScore = false;

    //Start is called before the first frame update.
    void Start()
    {


        if (ResetScore == false)
        {
            //ScoreReset();
            UpdateScore();
        }

        //Setting score to 0 at the start of the game.
        score = StartScore;

        //The text at the start of the game.
        ScoreText.text = "score: " + score;
        //HighScoreText.text = "Highscore: " + highScore;
        Debug.Log("Highscore: " + highScore);

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
        if (score == maxScore)
        {
            WinScreen.SetActive(true);
        }
    }

    public void UpdateScore()
    {
        //score += scoreUpdate;
        ScoreText.text = "score: " + score;

        //Reading the current score drom the text document
        using (StreamReader sr = new StreamReader(PathFinder()))
        {
            streamreaderline = sr.ReadLine();
            highScore = Convert.ToInt32(streamreaderline);

        }

        //If the current score is greater than or eqaul to the highscore, run this code.
        if (score >= highScore)
        {
            //Writing the new highscore to the text document.
            using (StreamWriter writer = new StreamWriter(PathFinder()))
            {
                writer.WriteLine(score);
            }
            //Updating the score on the UI.
            HighScoreText.text = "Highscore: " + score;

        }
        else
        {
            HighScoreText.text = "Highscore: " + highScore;
        }

    }

    private void OnTriggerEnter2D(Collider2D collisions)
    {
        //On collison checking if the "Collectable" tag is on the object.
        if (collisions.CompareTag("Collectable"))
        {
            //destroying the object
            Destroy(collisions.gameObject);

            //adding 10 to the score
            score = score + CollectibleScore;

            //updating the score text
            ScoreText.text = "score: " + score;

            //adding the score to the list
            Scores.Add(score);

            //writing list to file
            using (StreamWriter writer = new StreamWriter("Scores.txt"))
            {
                foreach (int s in Scores)
                {
                    writer.WriteLine(s);
                }
            }

        }
    }
    public void CreateHSFile()
    {
        string CheckPath = Application.dataPath + "/HighScores.txt";
        if (!File.Exists(CheckPath))
        {
            File.WriteAllText(CheckPath, Convert.ToString(highScore));

        }
    }
    // public void ScoreReset()
    // {
    //     if (ResetScore == false)
    //     {
    //         //Writing the new highscore to the text document.
    //         using (StreamWriter writer = new StreamWriter(PathFinder()))
    //         {
    //             writer.WriteLine(StartScore);
    //         }
    //         score = StartScore;
    //         highScore = StartScore;
    //         ResetScore = true;
    //     }

    // }

    string PathFinder()
    {
        string CheckPath = Application.dataPath + "/HighScores.txt";
        return CheckPath;
    }

}
