using UnityEngine;
using System.Collections;
using System;

public class SkipAnsw : MonoBehaviour {
    [SerializeField]
    private UFSButton _button;

    void Awake()
    {
        _button.Click += HelpAction;
    }

    void OnDestroy()
    {
        _button.Click -= HelpAction;
    }

    private void HelpAction()
    {
            QuestionPuzzle.Instance.Help = true;
            QuestionPuzzle.Instance.GetRandomQuestion();
            _button.interactable = false;
    }

    void OnDisable()
    {
        _button.interactable = true;
    }
}
