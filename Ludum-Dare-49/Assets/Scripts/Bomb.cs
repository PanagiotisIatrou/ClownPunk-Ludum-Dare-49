using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public void TriggerEffect2()

    {
        GameManager.Instance.GameOver();
    }

}
