using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFader : MonoBehaviour
{
	private float fadeOutTime = 0.35f;

	public void FadeOut()
	{
		StartCoroutine(fadeOut());
	}

	private IEnumerator fadeOut()
	{
		Destroy(GetComponent<Collider2D>());

		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		while (sr.color.a > 0f)
		{
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - (1f / 60f) / fadeOutTime);
			yield return null;
		}

		Destroy(gameObject);
	}
}
