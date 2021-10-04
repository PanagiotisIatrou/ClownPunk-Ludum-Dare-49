using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingClown : MonoBehaviour
{
    private void Update()
    {
        if (GameManager.Instance.getIsPlaying())
            return;


    }
}
