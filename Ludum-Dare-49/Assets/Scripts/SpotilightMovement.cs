using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotilightMovement : MonoBehaviour
{

    //public GameObject light;
    float smooth = 20f;
    float tiltAngle = 60f;
    float tiltAroundZ = -45f;
    float target = -90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Smoothly tilts a transform towards a target rotation.
        if(tiltAroundZ!=target && target == -90f)
        {
            titlAroundZ -= 1;
        }
        else if(tiltAroundZ != target && target == 0f)
        {
            titlAroundZ += 1;
        }
        else if (target == -90f)
        {
            target = 0f;
        }
        else
        {
            target = -90f;
        }

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

    }
}
