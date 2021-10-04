using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
	// Singleton
	private static PauseManager _instance;
	public static PauseManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<PauseManager>();
			}

			return _instance;
		}
	}

	private bool isPaused = false;
	public GameObject PausePanel;

	public static bool IsPaused()
	{
		return Instance.isPaused;
	}

    public static void Pause()
	{
		Instance.isPaused = true;
		Time.timeScale = 0f;
		Instance.PausePanel.SetActive(true);
	}

	public static void UnPause()
	{
		Instance.isPaused = false;
		Time.timeScale = 1f;
		Instance.PausePanel.SetActive(false);
	}
}
