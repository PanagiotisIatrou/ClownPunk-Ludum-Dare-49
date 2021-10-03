using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListeners : MonoBehaviour
{
	// Singleton
	private static ButtonListeners _instance;
	public static ButtonListeners Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<ButtonListeners>();
			}

			return _instance;
		}
	}

	public GameObject Play;
	public GameObject Menu;
	public GameObject HowToPlay;
	public GameObject Credits;
	public GameObject gameOver;
	
	public void OnPauseButtonListener()
	{
		PauseManager.Pause();
	}

	public void OnUnPauseButtonListener()
	{
		PauseManager.UnPause();
	}

	public void PlayButton()
	{
		Play.SetActive(true);
		Menu.SetActive(false);
		HowToPlay.SetActive(false);
		Credits.SetActive(false);
		gameOver.SetActive(false); 
		GameManager.Instance.changeRestart(true);
		GameManager.Instance.changeIsPlaying(true);
	}

	public void MenuButton()
	{
		Play.SetActive(false);
		Menu.SetActive(true);
		HowToPlay.SetActive(false);
		Credits.SetActive(false);
		gameOver.SetActive(false);
	}

	public void HowToPlayButton()
    {
		Play.SetActive(false);
		Menu.SetActive(false);
		HowToPlay.SetActive(true);
		Credits.SetActive(false);
		gameOver.SetActive(false);
	}

	public void CreditsButton()
	{
		Play.SetActive(false);
		Menu.SetActive(false);
		HowToPlay.SetActive(false);
		Credits.SetActive(true);
		gameOver.SetActive(false);
	}

	public void GameOver()
    {
		Play.SetActive(false);
		Menu.SetActive(false);
		HowToPlay.SetActive(false);
		Credits.SetActive(false);
		gameOver.SetActive(true)
	}
}
