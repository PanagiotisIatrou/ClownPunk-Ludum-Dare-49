using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
	public Transform hand;

	private void Update()
	{
		//transform.position = hand.position;
		transform.rotation = Quaternion.identity;
	}
}
