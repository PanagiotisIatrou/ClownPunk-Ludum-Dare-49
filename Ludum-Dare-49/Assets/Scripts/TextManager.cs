using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    // Singleton
    private static TextManager _instance;
    public static TextManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<TextManager>();
            }

            return _instance;
        }
    }

    // begin for point changing
    public TextMeshProUGUI TimeToChangeControls;
    
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    public int timeLeftToChange = 0;

    public TextMeshProUGUI Scoreboard;
    public TextMeshProUGUI GameOverScore;
    public TextMeshProUGUI HighScoreText;
    private int ScoreCounter;
    private int HighScore = 0;

    public void UpdateScore(int addScore)
    {
        if (!GameManager.Instance.getIsPlaying())
            return;
        ScoreCounter += addScore;
        if (HighScore < ScoreCounter)
        {
            HighScore = ScoreCounter;
        }
        Scoreboard.text = "Score: " + ScoreCounter.ToString();
        GameOverScore.text = "Score: " + ScoreCounter.ToString();
        HighScoreText.text = "High Score: " + HighScore.ToString();
    }
    void Update()
    {
        if (GameManager.Instance.getIsPlaying() == false)
            return;

        if (timeLeftToChange > 0)
        {
            TimeToChangeControls.text = "Time left before inverted :" + timeLeftToChange.ToString();
        }
        else
        {
            int timeleft = 5 + timeLeftToChange;
            TimeToChangeControls.text = "Time left for the inverted :" + timeleft.ToString();
        }
    }

    public void UpdateLeftWeight(int point)
    {
        leftText.text = point.ToString();
    }
    
    public void UpdateRightWeight(int point)
    {
        rightText.text = point.ToString();
    }

    public void Restart()
    {
        ScoreCounter = 0;
        timeLeftToChange = 0;
        TimeToChangeControls.text = "Time left before inverted :" + timeLeftToChange.ToString();
        Scoreboard.text = "Score: " + ScoreCounter.ToString();
        UpdateLeftWeight(0);
        UpdateRightWeight(0);
    }
}
