using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Starting : MonoBehaviour
{
    // Singleton
    private static Starting _instance;
    public static Starting Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Starting>();
            }

            return _instance;
        }

    }

    public GameObject BlackGO;
    public GameObject StaticGO;
    public GameObject VideoPlayerGO;
    public AudioSource themePlayer;
    private VideoPlayer rickRoll;

    private void Start()
    {
        rickRoll = VideoPlayerGO.GetComponent<VideoPlayer>();
        rickRoll.Prepare();
    }

    public void PressButton()
	{
        StartCoroutine(ButtonPress());
    }

    private IEnumerator ButtonPress()
	{
        StaticGO.SetActive(true);
        yield return new WaitForSeconds(1f);
        StaticGO.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        StaticGO.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        StaticGO.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        VideoPlayerGO.SetActive(true);
        yield return new WaitForSeconds((float)rickRoll.clip.length);
        StaticGO.SetActive(true);
        VideoPlayerGO.SetActive(false);
        yield return new WaitForSeconds(1f);
        StaticGO.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        StaticGO.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        StaticGO.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        BlackGO.SetActive(false);
        themePlayer.Play();
    }
}
