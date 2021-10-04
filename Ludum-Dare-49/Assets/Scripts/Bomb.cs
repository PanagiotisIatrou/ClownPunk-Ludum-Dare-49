using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public void TriggerEffect()
    {
        GameManager.Instance.GameOver();
        GetComponent<Animator>().SetTrigger("Trigger");
    }
}
