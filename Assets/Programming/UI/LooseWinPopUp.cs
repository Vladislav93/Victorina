using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LooseWinPopUp : MonoBehaviour {
    [SerializeField]
    private Text _winLooseTextTop;

    [SerializeField]
    private Image _winImage;

    [SerializeField]
    private Image _looseImage;

    [SerializeField]
    private Image _star1;

    [SerializeField]
    private GameObject _star1GO;

    [SerializeField]
    private Image _star2;

    [SerializeField]
    private GameObject _star2GO;

    [SerializeField]
    private Image _star3;

    [SerializeField]
    private GameObject _star3GO;

    [SerializeField]
    private Color _colorStars;

    [SerializeField]
    private UFSButton _button;

    [SerializeField]
    private Color _winTextColor;

    private Color tempColor;
    private bool _isItLooseOrWin;

    public static LooseWinPopUp Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        _button.Click += Close;
        Instance = this;
    }

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Init(bool winorloose)
    {

        Timer.Instance.StopTimer();
        AchivmentsMangaer.CheckAchivments();
        _winImage.enabled = false;
        _looseImage.enabled = false;
        _star1.color = _colorStars;
        _star2.color = _colorStars;
        _star3.color = _colorStars;
        _isItLooseOrWin = winorloose;
        gameObject.SetActive(true);
        WinLoosaeAction();
        LeanTween.scale(gameObject, Vector3.one * 0.1f, 1f).setEase(LeanTweenType.punch);
    }

    void OnDestroy()
    {
        _button.Click -= Close;
    }

    private void Close()
    {

        ButtonsList.Instance.RePaint();
        QuestionPuzzle.Instance.DisableGameObject.SetActive(false);
        QuestionPuzzle.Instance.ArrowsGameObject.SetActive(true);
        QuestionPuzzle.Instance.ArrowLeftGameObject.SetActive(false);
        QuestionPuzzle.Instance.gameObject.SetActive(false);
        QuestionPuzzle.Instance.IDButton._iconsGO.SetActive(true);
        QuestionPuzzle.Instance.CurrentNumberOfQuest = 0;
        QuestionPuzzle.Instance.Mistake = false;
        QuestionPuzzle.Instance.Help = false;
        BackgroundManager.Instance.Manager();
        gameObject.SetActive(false);
    }

    private void WinLoosaeAction()
    {
        tempColor.a = 255;
        tempColor = Color.white;
        if (_isItLooseOrWin)
        {
            foreach (string index in QuestionPuzzle.Instance._tempRightAnswList)
                QuestionPuzzle.Instance._globalRightAnswList.Add(index);


            QuestionPuzzle.Instance._tempRightAnswList.Clear();
            _winImage.enabled = true;
            _winLooseTextTop.color = _winTextColor;
            _winLooseTextTop.text = "Победа!";
       
            int starcount = QuestionPuzzle.Instance.StarGets;
            ShowStars(starcount);
        }
        else
        {
            QuestionPuzzle.Instance._tempRightAnswList.Clear();
                _looseImage.enabled = true;
                _winLooseTextTop.text = "Проигрыш!";
                _winLooseTextTop.color = Color.red;
        }
    }

    private void ShowStars(int stars)
    {

        switch(stars)
        {
            case 1:
                Invoke("ShowStar1", 0.3f);
                break;
            case 2:
                Invoke("ShowStar1", 0.5f);
                Invoke("ShowStar2", 1.1f);
                break;
            case 3:
                Invoke("ShowStar1", 0.5f);
                Invoke("ShowStar2", 1.1f);
                Invoke("ShowStar3", 1.7f);
                break;
        }
    }

    private void ShowStar1()
    {
        _star1.color = tempColor;
        LeanTween.scale(_star1GO, Vector3.one * 0.1f, 1f).setEase(LeanTweenType.punch);
    }

    private void ShowStar2()
    {
        _star2.color = tempColor;
        LeanTween.scale(_star2GO, Vector3.one * 0.1f, 1f).setEase(LeanTweenType.punch);
    }

    private void ShowStar3()
    {
        _star3.color = tempColor;
        LeanTween.scale(_star3GO, Vector3.one * 0.1f, 1f).setEase(LeanTweenType.punch);
    }
}
