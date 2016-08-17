using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuestionPuzzle : MonoBehaviour
{
    public QuestionTextsField _questAndAnswerField;

    public int CurrentNumberOfQuest;

    public bool Mistake = false;

    public bool Help = false;

    public bool twoAnsw = false;

    public Text TabloText;

    public Image RightAnswImage;

    public int StarGets;

    [SerializeField]
    private List<QuestionButtonPressedAction> _buttons = new List<QuestionButtonPressedAction>();

    [SerializeField]
    private List<Image> _buttonsImage = new List<Image>();
    public ButtonAction IDButton;

    public UFSButton WrongButton;
    public string RightAnswer;

    public List<int> _tempIndexList = new List<int>();

    public GameObject DisableGameObject;

    public GameObject ArrowsGameObject;

    public GameObject ArrowLeftGameObject;

    public List<string> _tempRightAnswList = new List<string>();

    public List<string> _globalRightAnswList = new List<string>();

    public static QuestionPuzzle Instance
    {
        get;
        private set;
    }
    public void Init()
    {
        Instance = this;
    }


    private void Awake()
    {

        Init();
        gameObject.SetActive(false);
    }


    public void GetRandomQuestion()
    {
        DisableGameObject.SetActive(false);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        LeanTween.scale(gameObject, Vector3.one * 0.03f, 1f).setEase(LeanTweenType.punch);
        StarGets = 0;
        TabloText.text = string.Format("{0}/{1}", CurrentNumberOfQuest, IDButton.QuestionCapacity);
        foreach (Image img in _buttonsImage)
        {
            img.color = Color.white;
        }
        int random = Random.Range(0, ManagerListFromXML.Instance.Quest.Count);
        if (_globalRightAnswList.Count > 43)
            _globalRightAnswList.Clear();
        while (_tempRightAnswList.Contains(ManagerListFromXML.Instance.Quest[random].RightAnswer) || _globalRightAnswList.Contains(ManagerListFromXML.Instance.Quest[random].RightAnswer))
        {
            random = Random.Range(0, ManagerListFromXML.Instance.Quest.Count);
        }
        _tempRightAnswList.Add(ManagerListFromXML.Instance.Quest[random].RightAnswer);
        RightAnswer = ManagerListFromXML.Instance.Quest[random].RightAnswer;
        _questAndAnswerField._question.text = ManagerListFromXML.Instance.Quest[random].Question;

        int tempValue;
        while (_tempIndexList.Count< _questAndAnswerField._answer.Count)
        {
            tempValue = Random.Range(0, _questAndAnswerField._answer.Count);
            if (!_tempIndexList.Contains(tempValue))
                _tempIndexList.Add(tempValue);
        }

        _questAndAnswerField._answer[_tempIndexList[0]].text = ManagerListFromXML.Instance.Quest[random].RightAnswer;
        _questAndAnswerField._answer[_tempIndexList[1]].text = ManagerListFromXML.Instance.Quest[random].WrongAnswer1;
        _questAndAnswerField._answer[_tempIndexList[2]].text = ManagerListFromXML.Instance.Quest[random].WrongAnswer2;
        _tempIndexList.Clear();

        foreach(QuestionButtonPressedAction but in _buttons)
        {
            but.Init();
        }
    }

    public void XMLSaveCurrentStatus(int Stars)
    {
        StarGets = Stars;
        if (!PlayerPrefs.HasKey("Stars" + IDButton.ID.ToString()))
        {
            AllStarValue.Instance.Stars = AllStarValue.Instance.Stars + Stars;
            PlayerPrefs.SetInt("Stars" + IDButton.ID.ToString(), Stars);
        }
        else
            if (PlayerPrefs.GetInt("Stars" + IDButton.ID.ToString()) < Stars)
        {
            AllStarValue.Instance.Stars = AllStarValue.Instance.Stars + (Stars - PlayerPrefs.GetInt("Stars" + IDButton.ID.ToString()));
            PlayerPrefs.SetInt("Stars" + IDButton.ID.ToString(), Stars);
        }
              Social.ReportScore(AllStarValue.Instance.Stars, GPConstant.leaderboard_stars_count, (bool success) =>
              {
              });
        SaveAndLoad.Save();
    }
}
