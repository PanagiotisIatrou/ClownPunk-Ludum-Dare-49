using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hourglass : MonoBehaviour
{
    public void TriggerEffect()
	{
		SlowDownEffect.Instance.SlowDownForSeconds(1f);
	}
}
