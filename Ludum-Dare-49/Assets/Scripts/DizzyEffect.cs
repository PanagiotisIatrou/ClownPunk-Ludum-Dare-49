using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DizzyEffect : MonoBehaviour
{
	// Singleton
	private static DizzyEffect _instance;
	public static DizzyEffect Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<DizzyEffect>();
			}

			return _instance;
		}

	}

	public Volume dizzyEffectVolume;
	private Coroutine currentCoroutine;
	private ColorAdjustments colorAdjs;

	private void Start()
	{
		colorAdjs = (ColorAdjustments)dizzyEffectVolume.profile.components[0];
	}

	private IEnumerator getDizzyForSeconds(float secondsPerCycle, int cycles)
	{
		colorAdjs.hueShift.value = 0f;
		for (int i = 0; i < cycles; i++)
		{
			float value = 0f;
			while (value < 180f)
			{
				value += Time.deltaTime * 180f / secondsPerCycle;
				colorAdjs.hueShift.value = (value > 90f ? value - 180f : value);
				yield return null;
			}
			colorAdjs.hueShift.value = 0f;
		}
	}

	public void GetDizzyForSeconds(float secondsPerCycle, int cycles)
	{
		if (ButtonListeners.currentChannel == 2)
			return;

		if (currentCoroutine != null)
			StopCoroutine(currentCoroutine);
		currentCoroutine = StartCoroutine(getDizzyForSeconds(secondsPerCycle, cycles));
	}
}
