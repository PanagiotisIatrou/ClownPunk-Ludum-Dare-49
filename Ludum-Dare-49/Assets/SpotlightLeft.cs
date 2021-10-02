using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightLeft : MonoBehaviour
{
    //public GameObject light;
    float smooth = 10f;
    float tiltAroundZ = -45f;
    float targetRotation = -90f;

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
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

    }
}
