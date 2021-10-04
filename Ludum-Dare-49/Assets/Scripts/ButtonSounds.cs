using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public void OnPointerEnter(PointerEventData ped)
    {
		AudioSource.PlayClipAtPoint(GameManager.Instance.HoverSound, mainCamera.transform.position, 0.5f);
    }

    public void OnPointerDown(PointerEventData ped)
    {
        AudioSource.PlayClipAtPoint(GameManager.Instance.ClickSound, mainCamera.transform.position, 0.5f);
    }
}