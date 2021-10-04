using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownEyes : MonoBehaviour
{
	private SpriteRenderer sr;
	private float timer = 0f;
	private float timerMax = 5f;
	private float blinkTime = 1f;

	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if (sr.sprite == GameManager.Instance.ClownSprite)
		{
			if (timer >= timerMax)
			{
				timer = 0f;
				sr.sprite = GameManager.Instance.ClownEyesSprite;
			}
		}
		else
		{
			if (timer >= blinkTime)
			{
				timer = 0f;
				sr.sprite = GameManager.Instance.ClownSprite;
			}
		}
		
	}
}
