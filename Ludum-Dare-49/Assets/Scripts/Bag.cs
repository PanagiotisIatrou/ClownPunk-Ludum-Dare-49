using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
	public Transform HingeTR;
	private Transform hinge;

	private void Start()
	{
		if (transform.name == "Bag1")
			hinge = HingeTR.GetChild(0);
		else if (transform.name == "Bag2")
			hinge = HingeTR.GetChild(1);
	}

	private void Update()
	{
		transform.rotation = Quaternion.identity;
	}
}
