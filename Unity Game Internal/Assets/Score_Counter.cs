using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Score_Counter : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private int score;
    private int scoreWin = 9;
    public string WinText;
    // list of scores
    List<int> Scores = new List<int>();
    public int highScore;

    // Start is called before the first frame update
    void Start()
    {
        // setting score to 0 at the start of the game
        score = 0;
        ScoreText.text = "score: " + score;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score == scoreWin)
        {
            ScoreText.text = WinText;

        }
        //highScore = Scores.Max();
    }

    private void OnTriggerEnter2D(Collider2D collisions)
    {
        //On collison checking if the "Collectable" tag is on the object.
        if (collisions.CompareTag("Collectable"))
        {
            //destroying the object
            Destroy(collisions.gameObject);

            //adding 1 to the score
            score = score + 1;

            //updating the score text
            ScoreText.text = "score: " + score;

            //adding the score to the list
            Scores.Add(score);

            //writing list to file
            using (StreamWriter writer = new StreamWriter("Score.txt"))
            {
                foreach (int s in Scores)
                {
                    writer.WriteLine(s);
                }
            }
            
                
        }
    }
}
