using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
	public void TriggerEffect()
	{
		GameManager.Instance.BagMovementScript.ApplyInvertEffect();
		DizzyEffect.Instance.GetDizzyForSeconds(1f, 2);
	}
}
