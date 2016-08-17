using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class QuestionButtonPressedAction : MonoBehaviour
{ 
    [SerializeField]
    private UFSButton _button;

    [SerializeField]
    private Text _textField;

    [SerializeField]
    private Image _image;

    private Color _color;

    public Animator anim;

    private AudioSource _audioSource;
    public AudioClip WinAudioClip;
    public AudioClip LooseAudioClip;
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
        if (_textField.text == QuestionPuzzle.Instance.RightAnswer)
        {
            QuestionPuzzle.Instance.RightAnswImage = _image;
        }
        else
        {
            QuestionPuzzle.Instance.WrongButton = _button;
        }
    }

    void OnDestroy()
    {

        _button.Click -= ButtonClick;
    }

    void GetRandom()
    {
       StopAllCoroutines();
        QuestionPuzzle.Instance.GetRandomQuestion();
        _button.targetGraphic.color = Color.white;
    }

    void Win()
    {
        if ((!PlayerPrefs.HasKey("SoundOff") || PlayerPrefs.GetInt("SoundOff") == 0))
        {
            _audioSource.clip = WinAudioClip;
            _audioSource.volume = 0.6f;
            _audioSource.Play();
        }
        AllStarValue.Instance.SaveStars();

        LooseWinPopUp.Instance.Init(true);
    }
    void Loose()
    {
        if ((!PlayerPrefs.HasKey("SoundOff") || PlayerPrefs.GetInt("SoundOff") == 0))
        {
            _audioSource.clip = LooseAudioClip;
            _audioSource.volume = 0.2f;
            _audioSource.Play();
        }

        LooseWinPopUp.Instance.Init(false);
    }


    private void ButtonClick()
    {

       
        QuestionPuzzle.Instance.DisableGameObject.SetActive(true);
        if (_textField.text == QuestionPuzzle.Instance.RightAnswer)
        {
            QuestionPuzzle.Instance.CurrentNumberOfQuest++;

            if (QuestionPuzzle.Instance.CurrentNumberOfQuest < QuestionPuzzle.Instance.IDButton.QuestionCapacity)
            {

                 StartCoroutine(ColorCourutin(_image, _color));
                 Invoke("GetRandom", 1.2f);
                if ((!PlayerPrefs.HasKey("SoundOff") || PlayerPrefs.GetInt("SoundOff") == 0))
                {
                    _audioSource.clip = RightAudioClip;
                    _audioSource.volume = 0.6f;
                    _audioSource.Play();
                }

            }

            else
            {
                if (!QuestionPuzzle.Instance.Mistake && !QuestionPuzzle.Instance.Help)
                {

                    QuestionPuzzle.Instance.XMLSaveCurrentStatus(3);
                }
                else if ((!QuestionPuzzle.Instance.Mistake && QuestionPuzzle.Instance.Help) || (QuestionPuzzle.Instance.Mistake && !QuestionPuzzle.Instance.Help))
                {
                    QuestionPuzzle.Instance.XMLSaveCurrentStatus(2);
                }
                else if (QuestionPuzzle.Instance.Mistake && QuestionPuzzle.Instance.Help)
                {
                    QuestionPuzzle.Instance.XMLSaveCurrentStatus(1);
                }

                StartCoroutine(ColorCourutin(QuestionPuzzle.Instance.RightAnswImage, _color));
                if ((!PlayerPrefs.HasKey("SoundOff") || PlayerPrefs.GetInt("SoundOff") == 0))
                {
                    _audioSource.clip = RightAudioClip;
                    _audioSource.volume = 0.6f;
                    _audioSource.Play();
                }
                Invoke("Win", 1.2f);
            }
        }

        else
        {
            if (!QuestionPuzzle.Instance.Mistake)
            {

                QuestionPuzzle.Instance.Mistake = true;
                _image.color = Color.red;

                StartCoroutine(ColorCourutin(QuestionPuzzle.Instance.RightAnswImage, _color));
                if ((!PlayerPrefs.HasKey("SoundOff") || PlayerPrefs.GetInt("SoundOff") == 0))
                {
                    _audioSource.clip = WrongAudioClip;
                    _audioSource.volume = 0.4f;
                    _audioSource.Play();
                }
                Invoke("GetRandom", 1.2f);

            }
            else
            {
                _image.color = Color.red;
                StartCoroutine(ColorCourutin(QuestionPuzzle.Instance.RightAnswImage, _color));
                if ((!PlayerPrefs.HasKey("SoundOff") || PlayerPrefs.GetInt("SoundOff") == 0))
                {
                    _audioSource.clip = WrongAudioClip;
                    _audioSource.volume = 0.4f;
                    _audioSource.Play();
                }
                Invoke("Loose", 1.2f);

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
