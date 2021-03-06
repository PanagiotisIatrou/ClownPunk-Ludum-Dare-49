using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
	private int weight = 1;
	private Camera mainCamera;

	private void Start()
	{
		mainCamera = Camera.main;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Bag"))
		{
			if (!ButtonListeners.isAudioMuted)
				AudioSource.PlayClipAtPoint(GameManager.Instance.ItemInBasketSound, mainCamera.transform.position, 1f);

			// Fade out
			GetComponent<SpriteFader>().FadeOut();

			// Apply effects
			if (GetComponent<Hourglass>())
				GetComponent<Hourglass>().TriggerEffect();
			else if (GetComponent<Bomb>())
			{
				GetComponent<Bomb>().TriggerEffect();
				if (!ButtonListeners.isAudioMuted)
					AudioSource.PlayClipAtPoint(GameManager.Instance.ExplosionSound, mainCamera.transform.position, 0.5f);
			}
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
			if (!ButtonListeners.isAudioMuted)
				AudioSource.PlayClipAtPoint(GameManager.Instance.ItemInWaterSound, mainCamera.transform.position, 0.5f);
			if (GetComponent<Scissors>() != null)
				GetComponent<Scissors>().TriggerEffect();
			// Fade out
			GetComponent<SpriteFader>().FadeOut();
		}
	}
}
