using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    public void TriggerEffect()

    {
        GameManager.Instance.GameOver();
    }

}
