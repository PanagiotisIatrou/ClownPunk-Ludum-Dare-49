using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagMovement : MonoBehaviour
{
    private float speed = 5f;

    private void Update()
    {
        Vector2 offset = Vector2.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
		{
            offset += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            offset += Vector2.right;
        }

        transform.position += (Vector3)offset * speed * Time.deltaTime;
    }
}
