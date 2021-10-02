using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BagMovement : MonoBehaviour
{
    public TextMeshProUGUI LeftBagText;
    public TextMeshProUGUI RightBagText;
    private Camera mainCamera;
    private float speed = 5f;

	private void Start()
	{
        mainCamera = Camera.main;
	}

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
        LeftBagText.transform.position = transform.GetChild(0).position;
        LeftBagText.transform.position += Vector3.back;
        RightBagText.transform.position = transform.GetChild(1).position;
        RightBagText.transform.position += Vector3.back;
    }
}
