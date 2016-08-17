using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class QuestionMarafon : MonoBehaviour
{
    public QuestionTextsField _questAndAnswerField;

    public int CurrentNumberOfQuest;

    public bool Mistake = false;

    public bool Help = false;

    public bool twoAnsw = false;

    public Text TabloText;

    public int StarGets;

    [SerializeField]
    private List<QuestionButtonPressedActionMarafon> _buttons = new List<QuestionButtonPressedActionMarafon>();

    [SerializeField]
    private List<Image> _buttonsImage = new List<Image>();

    public UFSButton WrongButton;
    public string RightAnswer;

    public List<int> _tempIndexList = new List<int>();

    public GameObject DisableGameObject;

    public Image RightAnswImage;

    public GameObject ArrowLeftGameObject;

    public List<string> _tempRightAnswList = new List<string>();

    public List<string> _globalRightAnswList = new List<string>();

    private int _index=0;
    public static QuestionMarafon Instance
    {
        get;
        private set;
    }
    public void Init()
    {
        Instance = this;
        _index = 0;
    }


    private void Awake()
    {

        Init();
        TabloText.text = string.Format("{0}", CurrentNumberOfQuest);

        ManagerListFromXML.Instance.LoadXMLData("XMLMarafon");

    }

    private void Start()
    {
        ArrowLeftGameObject.SetActive(true);

        TimerMarafon.Instance.StartTimerCoroutine();

        GetRandomQuestion();
    }


    public void GetRandomQuestion()
    {
        DisableGameObject.SetActive(false);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        LeanTween.scale(gameObject, Vector3.one * 0.03f, 1f).setEase(LeanTweenType.punch);
        StarGets = 0;
        TabloText.text = string.Format("{0}", CurrentNumberOfQuest);
        foreach (Image img in _buttonsImage)
        {
            img.color = Color.white;
        }
        int random = Random.Range(0, ManagerListFromXML.Instance.Quest.Count);
        if (_globalRightAnswList.Count > 80)
            _globalRightAnswList.Clear();
        while (_tempRightAnswList.Contains(ManagerListFromXML.Instance.Quest[random].RightAnswer) || _globalRightAnswList.Contains(ManagerListFromXML.Instance.Quest[random].RightAnswer))
        {
            random = Random.Range(0, ManagerListFromXML.Instance.Quest.Count);
        }
        _tempRightAnswList.Add(ManagerListFromXML.Instance.Quest[random].RightAnswer);
        RightAnswer = ManagerListFromXML.Instance.Quest[random].RightAnswer;
        _questAndAnswerField._question.text = ManagerListFromXML.Instance.Quest[random].Question;

        int tempValue;
        while (_tempIndexList.Count< _questAndAnswerField._answer.Count )
        {
            tempValue = Random.Range(0, _questAndAnswerField._answer.Count);
            if (!_tempIndexList.Contains(tempValue))
                        _tempIndexList.Add(tempValue);

        }


            _questAndAnswerField._answer[_index != _tempIndexList[0] ? _tempIndexList[0] : _tempIndexList[1]].text = 
                ManagerListFromXML.Instance.Quest[random].RightAnswer;
            _questAndAnswerField._answer[_index != _tempIndexList[0] ? _tempIndexList[1] : _tempIndexList[0]].text =
                ManagerListFromXML.Instance.Quest[random].WrongAnswer1;
            _questAndAnswerField._answer[_tempIndexList[2]].text =
                ManagerListFromXML.Instance.Quest[random].WrongAnswer2;



        _index = _index != _tempIndexList[0] ? _tempIndexList[0] : _tempIndexList[1];


        _tempIndexList.Clear();

        foreach(QuestionButtonPressedActionMarafon but in _buttons)
        {
            but.Init();
        }
    }

    public void ActionRightOrWin(bool flag)
    {
        
    }

}
