using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

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

	public GameObject VideoPlayerGO;
	private VideoPlayer videoPlayer;
	private RawImage videoImage;
	public AudioSource theme;
	public GameObject BlackerImage;
	public GameObject StaticGO;
	public AudioSource StaticAudio;

	public Image AudioButtonImage;
	public Image MusicButtonImage;

	private bool isPowerOn = false;
	private bool hasPressedPowerButton = false;
	private int currentChannel = 1;
	private Camera mainCamera;

	private bool isHelpOn = false;

	private bool isMusicMuted = false;
	public static bool isAudioMuted = false;

	private Coroutine currentCoroutine;

	private void Start()
	{
		mainCamera = Camera.main;
		videoImage = VideoPlayerGO.GetComponent<RawImage>();
		videoPlayer = VideoPlayerGO.GetComponent<VideoPlayer>();
		videoPlayer.Prepare();
		videoPlayer.frame = 0;
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
			videoImage.enabled = false;
			videoPlayer.Stop();
		}

		if (!isAudioMuted)
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

	public void OnMuteMusicButtonListener()
	{
		isMusicMuted = !isMusicMuted;
		if (isMusicMuted)
		{
			theme.volume = 0f;
			MusicButtonImage.sprite = GameManager.Instance.MusicOffSprite;
		}
		else
		{
			theme.volume = 0.5f;
			MusicButtonImage.sprite = GameManager.Instance.MusicOnSprite;
		}
	}

	public void OnSFXMusicButtonListener()
	{
		isAudioMuted = !isAudioMuted;
		if (isAudioMuted)
		{
			AudioButtonImage.sprite = GameManager.Instance.AudioOffSprite;
			StaticAudio.volume = 0f;
		}
		else
		{
			AudioButtonImage.sprite = GameManager.Instance.AudioOnSprite;
			StaticAudio.volume = 1f;
		}
	}

	private IEnumerator OpenChannel1()
	{
		videoImage.enabled = false;
		videoPlayer.Stop();
		StaticGO.SetActive(true);
		StaticAudio.Play();
		yield return new WaitForSeconds(0.5f);
		StaticGO.SetActive(false);
		StaticAudio.Stop();
		theme.Play();
	}

	private IEnumerator OpenChannel2()
	{
		if (PauseManager.IsPaused())
			PauseManager.UnPause();

		StaticGO.SetActive(true);
		StaticAudio.Play();
		theme.Stop();
		yield return new WaitForSeconds(0.5f);
		videoPlayer.frame = 0;
		videoImage.enabled = true;
		videoPlayer.Play();
		StaticGO.SetActive(false);
		StaticAudio.Stop();
	}
}
