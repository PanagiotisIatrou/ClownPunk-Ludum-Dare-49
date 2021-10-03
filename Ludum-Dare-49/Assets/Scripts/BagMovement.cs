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
    private float boost = 0f;
    private float timeboost = 0f;
    private float time = 0f;

	private void Start()
	{
        mainCamera = Camera.main;
	}

    public void Restart()
    {
        speed = 5f;
        boost = 0f;
        timeboost = 0f;
        time = 0f;
    }

	private void Update()
    {
        if (!GameManager.Instance.getIsPlaying())
            return;

        timeboost -= Time.deltaTime;
        time += Time.deltaTime;
        Vector2 offset = Vector2.zero;
        TextManager.Instance.timeLeftToChange = 16 - (int)Math.Round(time);
        if (time < 16f)
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
        if (time > 20f)
            time = 0f;

        // Turn wheel
        if (offset.x > 0)
            clownWheel.transform.Rotate(new Vector3(0f, 0f, -Time.deltaTime * 270f));
        else if (offset.x < 0)
            clownWheel.transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * 270f));

        if (timeboost > 0)
        {
            speed = 5f * boost;
        }
        else
        {
            speed = 5f;
        }
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

    public void GiveTimeBoost(float takeTimeBoost, float takeBoost)
    {
        timeboost = takeTimeBoost;
        boost = takeBoost;
    }
}
