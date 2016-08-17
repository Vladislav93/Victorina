using UnityEngine;
using System.Collections;
using System;

public class test : MonoBehaviour {

    public UFSButton _button;

    void Awake()
    {
        _button.Click += actionbut;
    }

    private void actionbut()
    {
        PlayerPrefs.DeleteAll();
    }
}
