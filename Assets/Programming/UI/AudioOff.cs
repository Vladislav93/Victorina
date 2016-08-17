using UnityEngine;
using System.Collections;
using JetBrains.Annotations;

public class AudioOff : MonoBehaviour
{

    public UFSButton SoundButton;
    public GameObject ForbiddeGameObject;
    private AudioSource _audioSource;
    void Awake()
    {
        SoundButton.Click += SaveSoundOff;
        _audioSource = gameObject.GetComponent<AudioSource>();

    }

    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("SoundOff"));
        if (PlayerPrefs.GetInt("SoundOff") == 1)
        {
            ForbiddeGameObject.SetActive(false);
            _audioSource.mute = true;
        }
        else
        {
            ForbiddeGameObject.SetActive(true);
        }
    }
    void OnDestroy()
    {
        SoundButton.Click -= SaveSoundOff;
    }

    void SaveSoundOff()
    {
        if (PlayerPrefs.HasKey("SoundOff"))
        {
            if (PlayerPrefs.GetInt("SoundOff") == 1)
            {
                PlayerPrefs.SetInt("SoundOff", 0);
               
                if(_audioSource!=null)
                _audioSource.mute = false;
                ForbiddeGameObject.SetActive(true);
            }
            else
            {
                if (_audioSource != null)
                    _audioSource.mute = true;

                ForbiddeGameObject.SetActive(false);
                PlayerPrefs.SetInt("SoundOff", 1);
            }
        }
        else
        {
            if (_audioSource != null)
                _audioSource.mute = true;
            ForbiddeGameObject.SetActive(false);
            PlayerPrefs.SetInt("SoundOff", 1);
        }

    }
}
