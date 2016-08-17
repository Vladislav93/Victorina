using UnityEngine;
using System.Collections;
using System;

public class TwoAnswers : MonoBehaviour
{

    [SerializeField] private UFSButton _button;

    void Awake()
    {
        _button.Click += ButtonHelp;
    }

    void OnDestroy()
    {
        _button.Click -= ButtonHelp;
    }


    private void ButtonHelp()
    {
        if (TwoAnswersHelp.Instance.Count > 0)
        {
            QuestionPuzzle.Instance.WrongButton.interactable = false;
            _button.interactable = false;
            TwoAnswersHelp.Instance.Count = TwoAnswersHelp.Instance.Count - 1;
            TwoAnswersHelp.Instance.SaveCount();
        }
    }

    void OnEnable()
    {
        if (TwoAnswersHelp.Instance.Count < 1)

        {
            _button.interactable = false;
        }
    }
    void OnDisable()
    {
        _button.interactable = true;
    }
}
