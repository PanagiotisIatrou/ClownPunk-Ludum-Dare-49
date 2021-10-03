using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTV : MonoBehaviour
{
	public Material mat;

	private void Update()
	{
		mat.SetTextureOffset("_MainTex", new Vector2(Random.Range(0f, 1f) * 240f / 240f, Random.Range(0f, 1f) * 180f / 180f));
	}
}
