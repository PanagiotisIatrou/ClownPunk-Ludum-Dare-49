using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightRight : MonoBehaviour
{
    //public GameObject light;
    private float smooth = 10f;
    private float tiltAroundZ = -45f;
    private float targetRotation = 0f;
    private float counter = 0f;
    // Update is called once per frame
    void Update()
    {
        // Smoothly tilts a transform towards a target rotation.
        if (tiltAroundZ >= targetRotation && targetRotation == -90f)
        {
            tiltAroundZ -= 0.05f;
        }
        else if (tiltAroundZ <= targetRotation && targetRotation == 0f)
        {
            tiltAroundZ += 0.05f;
        }
        else if (targetRotation == -90f)
        {
            targetRotation = 0f;
        }
        else if (targetRotation == 0f)
        {
            targetRotation = -90f;
        }

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);

        // Dampen towards the target rotation
        if (PauseManager.IsPaused() == false)
            counter += Time.deltaTime;
        transform.rotation = Quaternion.Slerp(transform.rotation, target, counter * smooth);

    }
}
