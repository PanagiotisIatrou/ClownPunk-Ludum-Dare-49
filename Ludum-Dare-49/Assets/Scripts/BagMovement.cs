using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BagMovement : MonoBehaviour
{
    public TextMeshProUGUI LeftBagText;
    public TextMeshProUGUI RightBagText;
    public Transform clownWheel;
    private Camera mainCamera;
    private float speed = 5f;
    private bool isInvertOn = false;
    private float invertTimer = 0f;
    private float invertTimerMax = 2f;

	private void Start()
	{
        mainCamera = Camera.main;
	}

    public void Restart()
    {
        speed = 5f;
    }

	private void Update()
    {
        if (!GameManager.Instance.getIsPlaying())
            return;

        if (isInvertOn)
		{
            invertTimer += Time.deltaTime;
            if (invertTimer >= invertTimerMax)
                isInvertOn = false;
        }

        Vector2 offset = Vector2.zero;
        if (!isInvertOn)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                offset += Vector2.left;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                offset += Vector2.right;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                offset += Vector2.right;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                offset += Vector2.left;
            }
        }

        // Turn wheel
        if (offset.x > 0)
            clownWheel.transform.Rotate(new Vector3(0f, 0f, -Time.deltaTime * 360f));
        else if (offset.x < 0)
            clownWheel.transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * 360f));

        Vector3 vector = (Vector3)offset * speed * Time.deltaTime;
        if (vector.x + transform.position.x > -3f && vector.x + transform.position.x < 3f)
        {
            transform.position += vector;
            LeftBagText.transform.position = transform.GetChild(0).position + new Vector3(0f, 0.1f);
            LeftBagText.transform.position += Vector3.back;
            RightBagText.transform.position = transform.GetChild(1).position + new Vector3(0f, 0.1f);
            RightBagText.transform.position += Vector3.back;
        }
    }
    
    public void ApplyInvertEffect()
	{
        isInvertOn = true;
        invertTimer = 0f;
	}
}
