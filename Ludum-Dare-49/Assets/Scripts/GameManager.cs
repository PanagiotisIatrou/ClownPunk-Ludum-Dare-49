using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    // begin for point changing
    public TextMeshProUGUI TimeToChangeControls;
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI rightText;
    public int leftWeight;
    public int rightWeight;
    public int timeLeftToChange = 0;

    // Start is called before the first frame update
    void Start()
    {
        leftWeight = 0;
        rightWeight = 0;
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

    // increase the point of the left bag and check the game over
    public void IncreasePointsLeft(int theNewPoints)
    {
        leftWeight += theNewPoints;
        leftText.text = leftWeight.ToString();
        if (leftWeight >= rightWeight + 3)
        {
            Debug.Log("GAME OVER");
        }
    }


    // increase the point of the right bag and check the game over
    public void IncreasePointsRight(int theNewPoints)
    {
        rightWeight += theNewPoints;
        rightText.text = rightWeight.ToString();
        if (rightWeight >= leftWeight + 3)
        {
            Debug.Log("GAME OVER");
        }
    }
}
