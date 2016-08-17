using UnityEngine;
using System.Collections;
using System;

public class ClickSound : MonoBehaviour
{


    public UFSButton ButtonClick;
	// Use this for initialization
	void Awake ()
	{

	    ButtonClick = gameObject.GetComponent<UFSButton>();
	    ButtonClick.Click += PlaySound;
	}

    void OnDestroy()
    {
        ButtonClick.Click -= PlaySound;
    }

    private void PlaySound()
    {
        if ((!PlayerPrefs.HasKey("SoundOff") || PlayerPrefs.GetInt("SoundOff") == 0))
        {
            ClickPlayManager.Instance.playClick();
        }
    }


}
