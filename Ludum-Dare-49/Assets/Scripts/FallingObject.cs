using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Bag") || collision.transform.name == "Bot")
		{
			gameObject.GetComponent<SpriteFader>().FadeOut();
		}
	}
}
