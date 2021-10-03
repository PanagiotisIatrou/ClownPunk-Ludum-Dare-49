using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
	private int weight = 1;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Bag"))
		{
			// Fade out
			GetComponent<SpriteFader>().FadeOut();

			// Apply effects
			if (GetComponent<Hourglass>())
				GetComponent<Hourglass>().TriggerEffect();
			else if (GetComponent<Bomb>())
				GetComponent<Bomb>().TriggerEffect();
			else if (GetComponent<FallingShark>())
				GetComponent<FallingShark>().TriggerEffect();
			else if (GetComponent<Bottle>())
				GetComponent<Bottle>().TriggerEffect();

			// Add weights
			if (collision.gameObject.name == "Bag1")
			{
				GameManager.Instance.IncreasePointsLeft(weight);
				TextManager.Instance.UpdateScore(weight);
			}
			else if (collision.gameObject.name == "Bag2")
			{
				GameManager.Instance.IncreasePointsRight(weight);
				TextManager.Instance.UpdateScore(weight);
			}
		}
		else if (collision.transform.name == "Ground")
		{
			if (GetComponent<Scissors>() != null)
				GetComponent<Scissors>().TriggerEffect();
			// Fade out
			GetComponent<SpriteFader>().FadeOut();
		}
	}
}
