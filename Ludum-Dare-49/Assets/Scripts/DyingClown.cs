using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingClown : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.name == "pool")
		{
			Vector3 spawnPos = new Vector3(transform.position.x, -3.47f, -2.5f);
			Instantiate(GameManager.Instance.ClownSharkPrefab, spawnPos, Quaternion.identity);
			Destroy(transform.parent.gameObject);
		}
	}
}
