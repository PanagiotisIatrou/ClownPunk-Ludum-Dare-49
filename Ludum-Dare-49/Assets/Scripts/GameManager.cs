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


    // Start is called before the first frame update
    void Start()
    {
        leftWeight = 0;
        rightWeight = 0;
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
        AirManager.Instance.StartAirLeft();
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
        AirManager.Instance.StartAirRight();
        checkForFlickering();

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
