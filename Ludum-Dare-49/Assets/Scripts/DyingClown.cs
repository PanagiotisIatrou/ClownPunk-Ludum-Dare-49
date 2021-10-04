using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingClown : MonoBehaviour
{
	private Camera mainCamera;

	private void Start()
	{
		mainCamera = Camera.main;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "pool")
		{
			if (!ButtonListeners.isAudioMuted)
				AudioSource.PlayClipAtPoint(GameManager.Instance.BombInWaterSound, mainCamera.transform.position, 0.5f);
			if (!ButtonListeners.isAudioMuted)
				AudioSource.PlayClipAtPoint(GameManager.Instance.GameOverSound, mainCamera.transform.position, 0.5f);
			Vector3 spawnPos = new Vector3(transform.parent.position.x, -3.47f, -2.5f);
			Instantiate(GameManager.Instance.ClownSharkPrefab, spawnPos, Quaternion.identity);
			Destroy(transform.parent.gameObject);
		}
	}
}
