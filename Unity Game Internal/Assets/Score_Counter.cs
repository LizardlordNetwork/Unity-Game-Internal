using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class Score_Counter : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public static int score;
    
    //List of scores.
    List<int> Scores = new List<int>();

    //The high score.
    public int highScore;

    //The line read by the stream reader.
    string streamreaderline;

    //The text displayed when the player beats the high score.
    public string WinText;

    //Start is called before the first frame update.
    void Start()
    {
        //Setting score to 0 at the start of the game.
        score = 0;

        //The text at the start of the game.
        ScoreText.text = "score: " + score;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Reading the current score drom the text document
        using (StreamReader sr = new StreamReader("HighScores.txt"))
        {
            streamreaderline = sr.ReadLine();
            highScore = Convert.ToInt32(streamreaderline);

        }

        //If the current score is greater than or eqaul to the highscore, run this code.
        if (score >= highScore)
        {
            //Writing the new highscore to the text document.
            using (StreamWriter writer = new StreamWriter("HighScores.txt"))
            {
                writer.WriteLine(score);
            }
            //Updating the score on the UI.
            ScoreText.text = "Highscore: " + score;

        }
        
    }
    
    public void UpdateScore(int scoreUpdate)
    {
        ScoreText.text = "score: " + score;
       
        score += scoreUpdate;
        
    }

    private void OnTriggerEnter2D(Collider2D collisions)
    {
        //On collison checking if the "Collectable" tag is on the object.
        if (collisions.CompareTag("Collectable"))
        {
            //destroying the object
            Destroy(collisions.gameObject);

            //adding 10 to the score
            score = score + 10;

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
}
