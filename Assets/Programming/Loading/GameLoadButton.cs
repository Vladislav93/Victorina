using UnityEngine;
using System.Collections;
using System;

public class GameLoadButton : MonoBehaviour {

    [SerializeField]
    private UFSButton _button;

    public int lvl;
    void Awake()
    {
        _button.Click += LoadAction;
    }
    void OnDestroy()
    {
        _button.Click -= LoadAction;
    }

    private void LoadAction()
    {
        Application.LoadLevelAsync(lvl);
    }
}
