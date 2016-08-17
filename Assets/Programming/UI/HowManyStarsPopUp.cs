using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HowManyStarsPopUp : MonoBehaviour
{

    public Text DescriptionText;
    public UFSButton ButtonNext;
    public static HowManyStarsPopUp Instance { get; private set; }
    void Awake()
    {
        ButtonNext.Click += Close;
        Instance = this;
        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        ButtonNext.Click -= Close;
    }

    void Close()
    {
        gameObject.SetActive(false);
    }

    public void Init(int ID)
    {
        DescriptionText.text = String.Format("Для открытия этого уровня осталось звёзд: {0}", (ManagerListFromXML.Instance.ButtonsData[ID].Need- AllStarValue.Instance.Stars ));
        gameObject.SetActive(true);
        LeanTween.scale(gameObject, Vector3.one * 0.1f, 1f).setEase(LeanTweenType.punch);
    }
}
