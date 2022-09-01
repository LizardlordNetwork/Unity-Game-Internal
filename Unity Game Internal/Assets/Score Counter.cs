using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Counter : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    private int score;
    private int scoreWin = 9;
    public string WinText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        ScoreText.text = "score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (score == scoreWin)
        {
            ScoreText.text = WinText;
            //Application.LoadLevel(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collisions)
    {
        if (collisions.CompareTag("Collectable"))
        {
            Destroy(collisions.gameObject);
            score = score + 1;
            ScoreText.text = "score: " + score;
        }
    }
}
