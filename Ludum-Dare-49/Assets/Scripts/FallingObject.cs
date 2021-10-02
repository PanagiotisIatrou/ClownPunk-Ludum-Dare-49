using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
	public int weight = 0;

	private void Start()
	{
		transform.position += Vector3.forward;
		weight = 1;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Bag") || collision.transform.name == "Bot")
		{
			gameObject.GetComponent<SpriteFader>().FadeOut();
			if (collision.gameObject.name == "Bag1")
            {
				GameManager.Instance.IncreasePointsLeft(weight);
			}
			else if(collision.gameObject.name == "Bag2")
            {
				GameManager.Instance.IncreasePointsRight(weight);
			}
		}
	}
}
