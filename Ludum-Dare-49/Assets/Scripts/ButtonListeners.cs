using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

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
		if (coroutine != null)
		{
			StopCoroutine(coroutine);
			StartCoroutine(GameOverEffectOff());
			StopCoroutine(coroutine);
		}
		Play.SetActive(true);
		Menu.SetActive(false);
		HowToPlay.SetActive(false);
		Credits.SetActive(false);
		gameOver.SetActive(false); 
		GameManager.Instance.Restart();
		GameManager.Instance.changeIsPlaying(true);
	}

	public void MenuButton()
	{
		if (coroutine != null)
		{
			StopCoroutine(coroutine);
			StartCoroutine(GameOverEffectOff());
			StopCoroutine(coroutine);
		}
		Play.SetActive(false);
		Menu.SetActive(true);
		HowToPlay.SetActive(false);
		Credits.SetActive(false);
		gameOver.SetActive(false);
	}

	public void HowToPlayButton()
    {
		if (coroutine != null)
		{
			StopCoroutine(coroutine);
			StartCoroutine(GameOverEffectOff());
			StopCoroutine(coroutine);
		}
		Play.SetActive(false);
		Menu.SetActive(false);
		HowToPlay.SetActive(true);
		Credits.SetActive(false);
		gameOver.SetActive(false);
	}

	public void CreditsButton()
	{
		if (coroutine != null)
        {
			StopCoroutine(coroutine);
			StartCoroutine(GameOverEffectOff());
			StopCoroutine(coroutine);
		}
		StopCoroutine(coroutine);
		Play.SetActive(false);
		Menu.SetActive(false);
		HowToPlay.SetActive(false);
		Credits.SetActive(true);
		gameOver.SetActive(false);
	}

	public void GameOver()
    {
		if (coroutine != null)
			StopCoroutine(coroutine);
		StartCoroutine(GameOverEffectOn());
		Play.SetActive(false);
		Menu.SetActive(false);
		HowToPlay.SetActive(false);
		Credits.SetActive(false);
		gameOver.SetActive(true);
	}

	private float timeToSet = 0.5f;
	private Coroutine coroutine;
	public Volume effects;

	private IEnumerator GameOverEffectOn()
	{
		Vignette vignette = (Vignette)effects.profile.components[0];
		while (vignette.intensity.value < 0.5f)
		{
			vignette.intensity.value += 0.5f * Time.deltaTime / timeToSet;
			yield return null;
		}
		vignette.intensity.value = 0.5f;
	}

	private IEnumerator GameOverEffectOff()
	{
		Vignette vignette = (Vignette)effects.profile.components[0];
		while (vignette.intensity.value > 0f)
		{
			vignette.intensity.value -= 0.5f * Time.deltaTime / timeToSet;
			yield return null;
		}
		vignette.intensity.value = 0f;
	}

}
