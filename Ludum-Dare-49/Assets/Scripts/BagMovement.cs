using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BagMovement : MonoBehaviour
{
    public TextMeshProUGUI LeftBagText;
    public TextMeshProUGUI RightBagText;
    private Camera mainCamera;
    private float speed = 5f;
    private float time = 0f;

	private void Start()
	{
        mainCamera = Camera.main;
	}

	private void Update()
    {
        time += Time.deltaTime;
        Vector2 offset = Vector2.zero;
        Debug.Log(time);
        GameManager.Instance.timeLeftToChange = 16 - (int)Math.Round(time);
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
        

        transform.position += (Vector3)offset * speed * Time.deltaTime;
        LeftBagText.transform.position = transform.GetChild(0).position;
        LeftBagText.transform.position += Vector3.back;
        RightBagText.transform.position = transform.GetChild(1).position;
        RightBagText.transform.position += Vector3.back;
    }
}
