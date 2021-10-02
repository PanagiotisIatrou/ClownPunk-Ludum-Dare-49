using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsManager : MonoBehaviour
{
    // Singleton
    private static BuffsManager _instance;
    public static BuffsManager Instance
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

    public GameObject player;
 
    public void IncreaseMovementSpeed(float timeboost = 5f, float boost = 2f)
    {
        player.GetComponent<BagMovement>().GiveTimeBoost(timeboost, boost);
    }

    public void DecreaseMovementSpeed(float timeboost = 5f, float boost = 1 / 2f)
    {
        player.GetComponent<BagMovement>().GiveTimeBoost(timeboost, boost);
    }
}
