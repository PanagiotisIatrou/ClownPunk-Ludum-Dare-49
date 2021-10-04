using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    public Sprite SharkRightSprite;
    public Sprite SharkUpSprite;
    public BagMovement BagMovementScript;
    public GameObject text;
    public GameObject objectSpawner;
    public GameObject airManager;
    public GameObject Play;
    public GameObject Menu;
    public GameObject HowToPlay;
    public GameObject Credits;
    public GameObject gameOver;
    public Volume effects;
    public GameObject ClownSharkPrefab;
    public GameObject ClownPrefab;
    public TextMeshProUGUI LeftBagText;
    public TextMeshProUGUI RightBagText;
    public Sprite ClownSprite;
    public Sprite ClownEyesSprite;
    public AudioClip ItemInBasketSound;
    public AudioClip ItemThrowSound;
    public AudioClip ClickSound;
    public AudioClip HoverSound;
    public AudioClip StaticSound;
    public AudioClip TVOpenSound;
    public AudioClip ItemInWaterSound;
    public AudioClip BombInWaterSound;
    public AudioClip GameOverSound;
    public AudioClip ExplosionSound;
    public Sprite AudioOffSprite;
    public Sprite AudioOnSprite;
    public Sprite MusicOffSprite;
    public Sprite MusicOnSprite;

    private int leftWeight;
    private int rightWeight;
    private bool isPlaying = false;
    private float timeToSet = 0.2f;
    private IEnumerator coroutine;

    private void Start()
    {
        leftWeight = 0;
        rightWeight = 0;
    }

    private void Update()
    {
        if (!isPlaying)
            return;
    }

    public bool getIsPlaying()
    {
        return isPlaying;
    }

    public void changeIsPlaying(bool newIsPlaying)
    {
        isPlaying = newIsPlaying;
    }

    public int getLeftWeight()
    {
        return leftWeight;
    }

    public int getRightWeight()
    {
        return rightWeight;
    }

    // increase the point of the left bag and check the game over
    public void IncreasePointsLeft(int theNewPoints)
    {
        leftWeight += theNewPoints;
        TextManager.Instance.UpdateLeftWeight(leftWeight);
        checkForFlickering();

        if (leftWeight >= rightWeight + 3)
        {
            GameOver();
        }
    }

    // increase the point of the right bag and check the game over
    public void IncreasePointsRight(int theNewPoints)
    {
        rightWeight += theNewPoints;
        TextManager.Instance.UpdateRightWeight(rightWeight);
        checkForFlickering();
        AirManager.Instance.StartAirLeft();
        if (rightWeight >= leftWeight + 3)
        {
            GameOver();
        }
    }

    public void Restart()
    {
        text.GetComponent<TextManager>().Restart();
        objectSpawner.GetComponent<ObjectSpawner>().Restart();
        airManager.GetComponent<AirManager>().Restart();
        BagMovementScript.Restart();
        leftWeight = 0;
        rightWeight = 0;
    }
    
    private void checkForFlickering(){
         if (leftWeight >= rightWeight + 1)
        {
            LightManager.Instance.flickeringOff();
        }
        if (leftWeight == rightWeight + 2)
        {
            LightManager.Instance.flickeringOn();
        }
        if (rightWeight >= leftWeight + 1)
        {
            LightManager.Instance.flickeringOff();
        }
        if (rightWeight == leftWeight + 2)
        {
            LightManager.Instance.flickeringOn();
        }
    }

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

    private bool flage = false;

    public void GameOver()
    {
        flage = true;
        isPlaying = false;
        Destroy(BagMovementScript.transform.GetChild(2).GetComponent<CapsuleCollider2D>());
        BagMovementScript.transform.GetChild(2).GetComponent<BoxCollider2D>().enabled = true;
        Restart();
        if (coroutine != null)
            StopCoroutine(coroutine);
        StartCoroutine(GameOverEffectOn());
        Play.SetActive(false);
        Menu.SetActive(false);
        HowToPlay.SetActive(false);
        Credits.SetActive(false);
        gameOver.SetActive(true);
    }

    public void StopTheSpecialEffect()
    {
        if (!flage)
            return;
        flage = false;
        if (coroutine != null)
            StopCoroutine(coroutine);
        StartCoroutine(GameOverEffectOff());
        if (coroutine != null)
            StopCoroutine(coroutine);
    }

    public void SpawnClown()
	{
        Instantiate(ClownPrefab, new Vector3(0.08f, -2.3f, -2f), Quaternion.identity);
	}
}
