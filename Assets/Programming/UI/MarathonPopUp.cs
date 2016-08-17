using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MarathonPopUp : MonoBehaviour
{

    public UFSButton ExitButton, RepeatButton;
    public Text TextTablo;

    public static MarathonPopUp Instance { get; private set; }
    private AudioSource _audioSource;
    public AudioClip WinAudioClip;
    public AudioClip LooseAudioClip;

    void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        Instance = this;
        ExitButton.Click += Exit;
        RepeatButton.Click += Repeat;
        gameObject.SetActive(false);
    }


    void OnDestroy()
    {
        ExitButton.Click -= Exit;
        RepeatButton.Click -= Repeat;
    }

    public void Init()
    {
        Debug.Log("init");
        gameObject.SetActive(true);
        LeanTween.scale(gameObject, Vector3.one * 0.1f, 1f).setEase(LeanTweenType.punch);
        TimerMarafon.Instance.StopTimer();
        int count = QuestionMarafon.Instance.CurrentNumberOfQuest;


        Social.ReportScore(count, GPConstant.leaderboard_marathon_count, (bool success) => { });

        if (count > AllStarValue.Instance.Marathon)
        {
            TextTablo.text = String.Format("Поздравляем! Вы побили свой рекорд!\n\nВаш рекорд: {0}", AllStarValue.Instance.Marathon);
            if ((!PlayerPrefs.HasKey("SoundOff") || PlayerPrefs.GetInt("SoundOff") == 0))
            {
                _audioSource.clip = WinAudioClip;
                _audioSource.volume = 0.6f;
                _audioSource.Play();
            }
        }
        else if (count == AllStarValue.Instance.Marathon)
        {
            TextTablo.text = String.Format("Вы дошли до своего рекорда!\n\nВаш рекорд: {0}", AllStarValue.Instance.Marathon);
            if ((!PlayerPrefs.HasKey("SoundOff") || PlayerPrefs.GetInt("SoundOff") == 0))
            {
                _audioSource.clip = WinAudioClip;
                _audioSource.volume = 0.6f;
                _audioSource.Play();
            }
        }
        else
        {
            TextTablo.text = String.Format("Ваш текущий счёт: {0}\n\nВаш рекорд: {1}", QuestionMarafon.Instance.CurrentNumberOfQuest, AllStarValue.Instance.Marathon);
            if ((!PlayerPrefs.HasKey("SoundOff") || PlayerPrefs.GetInt("SoundOff") == 0))
            {
                _audioSource.clip = LooseAudioClip;
                _audioSource.volume = 0.2f;
                _audioSource.Play();
            }
        }
        if (AllStarValue.Instance.Marathon < QuestionMarafon.Instance.CurrentNumberOfQuest)
        {
            AllStarValue.Instance.Marathon = QuestionMarafon.Instance.CurrentNumberOfQuest;
            AllStarValue.Instance.SaveMarathon();
        }
        gameObject.SetActive(true);
    }


    void Exit()
    {
        Application.LoadLevelAsync(1);
    }

    void Repeat()
    {
        Application.LoadLevelAsync(3);
    }
}
