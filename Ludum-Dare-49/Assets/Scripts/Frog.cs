using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Vector2 startPos;
    private float swayBoundX = 2f;
    private float swayBoundY = 0.5f;
    private float timer = 0f;

	private void Start()
	{
        startPos = transform.position;
    }

	private void Update()
    {
        timer += Time.deltaTime;
        transform.position = startPos + new Vector2(Mathf.Sin(timer * 0.5f) * swayBoundX, Mathf.Sin(timer) * swayBoundY);
    }
}
