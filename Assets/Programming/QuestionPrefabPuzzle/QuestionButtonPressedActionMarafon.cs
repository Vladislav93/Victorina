using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class QuestionButtonPressedActionMarafon : MonoBehaviour
{ 
    [SerializeField]
    private UFSButton _button;

    [SerializeField]
    private Text _textField;

    [SerializeField]
    private Image _image;

    private Color _color;

    private AudioSource _audioSource;

    public AudioClip RightAudioClip;
    public AudioClip WrongAudioClip;
    void Awake()
    {
        _button.Click += ButtonClick;
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void Init()
    {
        _color.a = 255;
        _color.b = 0;
        _color.r = 0;
        _color.g = 0.7f;
        _button.interactable = true;
        if (_textField.text == QuestionMarafon.Instance.RightAnswer)
        {
            QuestionMarafon.Instance.RightAnswImage = _image;
        }
        else
        {
            QuestionMarafon.Instance.WrongButton = _button;
        }
    }

    void OnDestroy()
    {

        _button.Click -= ButtonClick;
    }

    void GetRandom()
    {
       StopAllCoroutines();
        QuestionMarafon.Instance.GetRandomQuestion();
        _button.targetGraphic.color = Color.white;

    }

    private void ButtonClick()
    {
        QuestionMarafon.Instance.DisableGameObject.SetActive(true);
        if (_textField.text == QuestionMarafon.Instance.RightAnswer)
        {
            QuestionMarafon.Instance.CurrentNumberOfQuest++;
            StartCoroutine(ColorCourutin(_image, _color));
            Invoke("GetRandom", 0.6f);
            if ((!PlayerPrefs.HasKey("SoundOff") || PlayerPrefs.GetInt("SoundOff") == 0))
            {
                _audioSource.clip = RightAudioClip;
                _audioSource.volume = 0.6f;
                _audioSource.Play();
            }
            if (TimerMarafon.Instance.time< 26f)
                TimerMarafon.Instance.time += 5.1f;
            else
            {
                TimerMarafon.Instance.time = 30f;
            }
        }

        else
        {
                _image.color = Color.red;
                StartCoroutine(ColorCourutin(QuestionMarafon.Instance.RightAnswImage, _color));

            if (TimerMarafon.Instance.time > 7.1f)
            {
                Invoke("GetRandom", 0.6f);
                if ((!PlayerPrefs.HasKey("SoundOff") || PlayerPrefs.GetInt("SoundOff") == 0))
                {
                    _audioSource.clip = WrongAudioClip;
                    _audioSource.volume = 0.4f;
                    _audioSource.Play();
                }
                TimerMarafon.Instance.time -= 7.1f;
            }
            else
            {
                MarathonPopUp.Instance.Init();
            }
        }
    }

    private static float TimerUpdate=0.02f;

    private IEnumerator ColorCourutin(Image image, Color color)
    {
        if (color.g < 1)
            while (color.g < 1)
            {
                color.g = color.g + TimerUpdate;
                image.color = color;
                yield return new WaitForEndOfFrame();
            }
        else
        {
            while (color.g > 0.8f)
            {
                color.g = color.g - TimerUpdate;
                image.color = color;
                yield return new WaitForSeconds(TimerUpdate);
            }
        }
        StartCoroutine(ColorCourutin(image, color));
    }
}
