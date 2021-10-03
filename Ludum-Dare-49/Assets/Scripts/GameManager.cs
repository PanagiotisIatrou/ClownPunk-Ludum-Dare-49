using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    private int leftWeight;
    private int rightWeight;

    private bool restart = false;
    private bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        leftWeight = 0;
        rightWeight = 0;
    }
    void Update()
    {
        if (isPlaying)
        {
            if (restart)
            {
                leftWeight = 0;
                rightWeight = 0;
            }
        }
    }

    public bool getIsPlaying()
    {
        return isPlaying;
    }

    public bool getRestart()
    {
        return restart;
    }

    public void changeRestart(bool newRestart)
    {
        restart = newRestart;
    }

    public void changeIsPlaying(bool newIsPlaying)
    {
        isPlaying = newIsPlaying;
    }

    public int getLeftWeight()
    {
        return leftWeight;
    }

    public int getRightWeight()
    {
        return rightWeight;
    }

    // increase the point of the left bag and check the game over
    public void IncreasePointsLeft(int theNewPoints)
    {
        leftWeight += theNewPoints;
        TextManager.Instance.UpdateLeftWeight(leftWeight);
        checkForFlickering();

        if (leftWeight >= rightWeight + 3)
        {
            ButtonListeners.Instance.GameOver();
        }
    }


    // increase the point of the right bag and check the game over
    public void IncreasePointsRight(int theNewPoints)
    {
        rightWeight += theNewPoints;
        TextManager.Instance.UpdateRightWeight(rightWeight);
        checkForFlickering();
        AirManager.Instance.StartAirLeft();
        if (rightWeight >= leftWeight + 3)
        {
            ButtonListeners.Instance.GameOver();
        }
    }

    private void checkForFlickering(){
         if (leftWeight >= rightWeight + 1)
        {
            LightManager.Instance.flickeringOff();
        }
        if (leftWeight == rightWeight + 2)
        {
            LightManager.Instance.flickeringOn();
        }
        if (rightWeight >= leftWeight + 1)
        {
            LightManager.Instance.flickeringOff();
        }
        if (rightWeight == leftWeight + 2)
        {
            LightManager.Instance.flickeringOn();
        }
    }

}
