using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SlowDownEffect : MonoBehaviour
{
    // Singleton
    private static SlowDownEffect _instance;
    public static SlowDownEffect Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<SlowDownEffect>();
            }

            return _instance;
        }
    }

    public AudioSource themeSong;
    public Volume effects;
    private float timeToSet = 0.3f;
    private float slowDownFactor = 0.5f;
    private Coroutine coroutine;

    private IEnumerator slowDown()
	{
        while (Time.timeScale > slowDownFactor)
		{
            Time.timeScale -= Time.deltaTime / timeToSet;
            themeSong.pitch = Time.timeScale;
            ((Vignette)effects.profile.components[0]).intensity.value = 1f - Time.timeScale;
            yield return null;
		}
        Time.timeScale = slowDownFactor;
        themeSong.pitch = Time.timeScale;
        ((Vignette)effects.profile.components[0]).intensity.value = 1f - Time.timeScale;
    }

    private IEnumerator unSlowDown()
    {
        while (Time.timeScale < 1f)
        {
            Time.timeScale += Time.deltaTime / timeToSet;
            themeSong.pitch = Time.timeScale;
            ((Vignette)effects.profile.components[0]).intensity.value = 1f - Time.timeScale;
            yield return null;
        }
        Time.timeScale = 1f;
        themeSong.pitch = Time.timeScale;
        ((Vignette)effects.profile.components[0]).intensity.value = 1f - Time.timeScale;
    }

    private IEnumerator slowDownForSeconds(float time)
	{
        yield return slowDown();
        yield return new WaitForSeconds(time);
        yield return unSlowDown();
    }

    public void SlowDown()
	{
        if (coroutine != null)
            StopCoroutine(coroutine);
        StartCoroutine(slowDown());
	}

    public void UnSlowDown()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        StartCoroutine(unSlowDown());
    }

    public void SlowDownForSeconds(float time)
	{
        if (coroutine != null)
            StopCoroutine(coroutine);
        StartCoroutine(slowDownForSeconds(time));
    }
}
