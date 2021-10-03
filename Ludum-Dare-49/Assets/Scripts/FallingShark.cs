using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingShark : MonoBehaviour
{
    public void TriggerEffect()

    {
        GameManager.Instance.GameOver();
    }

}
