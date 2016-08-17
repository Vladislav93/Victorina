using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour {

    public int ID;
    
    [SerializeField]
    private Image Close;

    [SerializeField]
    private Image Star1;

    [SerializeField]
    private Image Star2;

    [SerializeField]
    private Image Star3;

    [SerializeField]
    private Text NumberOfCapacity;

    public int QuestionCapacity;

    [SerializeField]
    private string _path;

    public GameObject _iconsGO;

    public GameObject GO;

    [SerializeField]
    private int _lvl, _stroka;

    [SerializeField]
    private UFSButton _button;

    void Awake()
    {
        _button.Click += ClickAction;
       
    }
    void OnDestroy()
    {
        _button.Click -= ClickAction;
        ButtonsList.Instance.ButtonsListRepaint.Remove(this);


    }

    void Start()
    {
        CheckCurrentStatus();
        ButtonsList.Instance.ButtonsListRepaint.Add(this);
        NumberOfCapacity.text = ID.ToString();
    }

    private void ClickAction()
    {
        if (ManagerListFromXML.Instance.ButtonsData[ID].Need <= AllStarValue.Instance.Stars)
        {
            BackgroundManager.Instance.Manager(_lvl, _stroka);
            QuestionPuzzle.Instance.IDButton = this;
            ManagerListFromXML.Instance.LoadXMLData(_path);
            _iconsGO.SetActive(false);
            GO.SetActive(true);
            QuestionPuzzle.Instance.ArrowsGameObject.SetActive(false);
            QuestionPuzzle.Instance.ArrowLeftGameObject.SetActive(true);
            QuestionPuzzle.Instance.GetRandomQuestion();
            Timer.Instance._minutes = 2;
            Timer.Instance.StartTimerCoroutine();
        }
        else
        {
            HowManyStarsPopUp.Instance.Init(ID);
        }
    }

    public void CheckCurrentStatus()
    {
        if(ManagerListFromXML.Instance.ButtonsData[ID].Need <= AllStarValue.Instance.Stars)
        {
            Close.enabled = false;
            NumberOfCapacity.enabled = true;
            Star1.enabled = true;
            Star2.enabled = true;
            Star3.enabled = true;
            int currentStars;
            //_button.interactable = true;

            if (PlayerPrefs.HasKey("Stars" + ID.ToString()))
                currentStars = PlayerPrefs.GetInt("Stars" + ID.ToString());
            else
                currentStars = 0;


           Color temp1 = Star1.color;
            Color temp2 = Star2.color;
            Color temp3 = Star3.color;
            switch (currentStars)
            {
                case 0:
                    break;
                case 1:
                    temp2 = Color.white;
                    temp2.a = 100;
                    Star2.color = temp2;
                    break;
                case 2:
                    temp1 = Color.white;
                    temp1.a = 100;
                    Star1.color = temp1;

                    temp2 = Color.white;
                    temp2.a = 100;
                    Star2.color = temp2;
                    break;
                case 3:
                    temp1 = Color.white;
                    temp1.a = 100;
                    Star1.color = temp1;

                    temp2 = Color.white;
                    temp2.a = 100;
                    Star2.color = temp2;

                    temp3 = Color.white;
                    temp3.a = 100;
                    Star3.color = temp3;
                    break;
            }
        }
        else
        {
            //_button.interactable = false;
            Close.enabled = true;
            NumberOfCapacity.enabled = false;
            Star1.enabled = false;
            Star2.enabled = false;
            Star3.enabled = false;
        }
    }
}
