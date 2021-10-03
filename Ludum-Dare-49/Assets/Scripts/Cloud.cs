using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float speed = 0.3f; 

    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
