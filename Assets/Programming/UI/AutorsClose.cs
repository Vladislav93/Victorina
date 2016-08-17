using UnityEngine;
using System.Collections;
using System;

public class AutorsClose : MonoBehaviour
{

    [SerializeField] private UFSButton _button;

    void Awake()
    {
        _button.Click += Close;
        Close();
    }

    void OnEnable()
    {
        LeanTween.scale(gameObject, Vector3.one * 0.1f, 1f).setEase(LeanTweenType.punch);
    }
    void OnDestroy()
    {
        _button.Click -= Close;
    }

    private void Close()
    {
        gameObject.SetActive(false);
    }
}
