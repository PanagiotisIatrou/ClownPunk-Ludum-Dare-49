using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListeners : MonoBehaviour
{
    public void OnPauseButtonListener()
	{
		PauseManager.Pause();
	}

	public void OnUnPauseButtonListener()
	{
		PauseManager.UnPause();
	}
}
