using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightRight : MonoBehaviour
{
    //public GameObject light;
    private float smooth = 10f;
    private float tiltAroundZ = -45f;
    private float counter = 0f;
    // Update is called once per frame
    void Update()
    {
        tiltAroundZ = (Mathf.Sin(Time.time * 0.75f) * 90f + 90f) / 2 - 90f;

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);

        // Dampen towards the target rotation
        if (PauseManager.IsPaused() == false)
            counter += Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, target, counter * smooth);

    }
}
