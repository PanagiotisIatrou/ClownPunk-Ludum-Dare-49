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

	public GameObject Channel2Panel;
	public AudioSource theme;
	public GameObject BlackerImage;
	public GameObject StaticGO;
	public AudioSource StaticAudio;

	private bool isPowerOn = false;
	private bool hasPressedPowerButton = false;
	private int currentChannel = 1;
	private Camera mainCamera;

	private bool isHelpOn = false;

	private Coroutine currentCoroutine;

	private void Start()
	{
		mainCamera = Camera.main;
	}

	public void OnPowerButtonListener()
	{
		if (!isPowerOn)
		{
			isPowerOn = true;
			BlackerImage.SetActive(false);
			if (currentChannel == 1)
			{
				if (currentCoroutine != null)
					StopCoroutine(currentCoroutine);
				currentCoroutine = StartCoroutine(OpenChannel1());
			}
			else
			{
				if (currentCoroutine != null)
					StopCoroutine(currentCoroutine);
				currentCoroutine = StartCoroutine(OpenChannel2());
			}
		}
		else
		{
			isPowerOn = false;
			BlackerImage.SetActive(true);
			theme.Stop();
			Channel2Panel.SetActive(false);
		}

		AudioSource.PlayClipAtPoint(GameManager.Instance.TVOpenSound, mainCamera.transform.position, 0.5f);
	}

	public void OnPauseButtonListener()
	{
		if (!isPowerOn || !GameManager.Instance.getIsPlaying())
			return;

		if (currentChannel != 1)
			return;

		if (!PauseManager.IsPaused())
			PauseManager.Pause();
		else
			PauseManager.UnPause();
	}

	public void PlayButton()
	{
		if (!isPowerOn)
			return;

		if (currentChannel != 1)
			return;

		Play.SetActive(true);
		Menu.SetActive(false);
		HowToPlay.SetActive(false);
		Credits.SetActive(false);
		gameOver.SetActive(false);
		GameManager.Instance.Restart();
		GameManager.Instance.changeIsPlaying(true);
		GameManager.Instance.StopTheSpecialEffect();

		if (GameManager.Instance.BagMovementScript == null)
			GameManager.Instance.SpawnClown();
	}

	public void MenuButton()
	{
		if (!isPowerOn)
			return;

		if (currentChannel != 1)
			return;

		Play.SetActive(false);
		Menu.SetActive(true);
		HowToPlay.SetActive(false);
		Credits.SetActive(false);
		gameOver.SetActive(false);
		GameManager.Instance.StopTheSpecialEffect();
	}

	public void HowToPlayButton()
	{
		if (!isPowerOn)
			return;

		if (currentChannel != 1)
			return;

		isHelpOn = !isHelpOn;
		Credits.SetActive(false);
		HowToPlay.SetActive(isHelpOn);

		if (isHelpOn && !PauseManager.IsPaused())
		{
			PauseManager.Pause();
		}
		else if (!isHelpOn)
		{
			PauseManager.UnPause();
		}

	}

	public void CreditsButton()
	{
		if (!isPowerOn)
			return;

		if (currentChannel != 1)
			return;

		Play.SetActive(false);
		Menu.SetActive(false);
		HowToPlay.SetActive(false);
		Credits.SetActive(true);
		gameOver.SetActive(false);
		GameManager.Instance.StopTheSpecialEffect();
	}

	public void OnStartButtonListener()
	{
		if (!isPowerOn)
			return;

		if (currentChannel != 1)
			return;

		if (!hasPressedPowerButton)
		{
			Starting.Instance.PressButton();
			hasPressedPowerButton = true;
		}
	}

	public void OnChangeChannelButtonListener()
	{
		if (!isPowerOn)
			return;

		if (currentChannel == 1)
		{
			currentChannel = 2;
			if (currentCoroutine != null)
				StopCoroutine(currentCoroutine);
			currentCoroutine = StartCoroutine(OpenChannel2());
		}
		else
		{
			currentChannel = 1;
			if (currentCoroutine != null)
				StopCoroutine(currentCoroutine);
			currentCoroutine = StartCoroutine(OpenChannel1());
		}
	}

	private IEnumerator OpenChannel1()
	{
		Channel2Panel.SetActive(false);
		StaticGO.SetActive(true);
		StaticAudio.Play();
		yield return new WaitForSeconds(0.5f);
		StaticGO.SetActive(false);
		StaticAudio.Stop();
		theme.Play();
	}

	private IEnumerator OpenChannel2()
	{
		StaticGO.SetActive(true);
		StaticAudio.Play();
		theme.Stop();
		yield return new WaitForSeconds(0.5f);
		StaticGO.SetActive(false);
		StaticAudio.Stop();
		Channel2Panel.SetActive(true);
	}
}
