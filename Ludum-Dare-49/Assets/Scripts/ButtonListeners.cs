using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListeners : MonoBehaviour
{
	public GameObject Play;
	public GameObject Menu;
	public GameObject HowToPlay;
	public GameObject Credits;


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
	}

	public void MenuButton()
	{
		Play.SetActive(false);
		Menu.SetActive(true);
		HowToPlay.SetActive(false);
		Credits.SetActive(false);
	}

	public void HowToPlayButton()
    {
		Play.SetActive(false);
		Menu.SetActive(false);
		HowToPlay.SetActive(true);
		Credits.SetActive(false);
	}

	public void CreditsButton()
	{
		Play.SetActive(false);
		Menu.SetActive(false);
		HowToPlay.SetActive(false);
		Credits.SetActive(true);
	}

}
