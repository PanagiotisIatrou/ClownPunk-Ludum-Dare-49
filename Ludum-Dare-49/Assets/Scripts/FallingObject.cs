using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
	private int weight = 0;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Bag"))
		{
			// Apply effects
			if (GetComponent<Hourglass>())
				GetComponent<Hourglass>().TriggerEffect();

			// Fade out
			GetComponent<SpriteFader>().FadeOut();
			
			if (GetComponent<Bomb>())
				GetComponent<Bomb>().TriggerEffect2();

			// Add weights
			if (collision.gameObject.name == "Bag1")
			{
				GameManager.Instance.IncreasePointsLeft(weight);
				TextManager.Instance.UpdateScore(weight);
				//BuffsManager.Instance.IncreaseMovementSpeed();
			}
			else if (collision.gameObject.name == "Bag2")
			{
				GameManager.Instance.IncreasePointsRight(weight);
				TextManager.Instance.UpdateScore(weight);
				//BuffsManager.Instance.DecreaseMovementSpeed();
			}
		}
		else if (collision.transform.name == "Ground")
		{
			// Fade out
			GetComponent<SpriteFader>().FadeOut();
		}
	}
}
