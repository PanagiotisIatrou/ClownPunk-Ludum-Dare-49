using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
	private void Start()
	{
		transform.position += Vector3.forward;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Bag") || collision.transform.name == "Bot")
		{
			gameObject.GetComponent<SpriteFader>().FadeOut();
		}
	}
}
