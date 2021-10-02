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
    public int ScoreCounter;
    public void UpdateScore(int addScore)
    {
        ScoreCounter += addScore;
        Scoreboard.text = "Score: " + ScoreCounter.ToString();
    }
    void Update()
    {
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

}
