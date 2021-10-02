using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool isPaused = false;

	public static bool IsPaused()
	{
		return isPaused;
	}

    public static void Pause()
	{
		isPaused = true;
		Time.timeScale = 0f;
	}

	public static void UnPause()
	{
		isPaused = false;
		Time.timeScale = 1f;
	}
}
