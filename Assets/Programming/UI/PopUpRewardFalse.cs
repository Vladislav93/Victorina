using UnityEngine;
using System.Collections;
using System;

public class PopUpRewardFalse : MonoBehaviour
{

    [SerializeField] private UFSButton _button;

    [SerializeField]
    private GameObject _goback;

    public static PopUpRewardFalse Instance { get; private set; }



    void Awake()
    {
        Instance = this;
        _button.Click += PopUpClose;
    }

    void Start()
    {
        PopUpClose();
        _goback.SetActive(false);
    }
    void OnDestroy()
    {
        _button.Click -= PopUpClose;
    }

    public void Init()
    {
       gameObject.SetActive(true);
        _goback.SetActive(true);
        LeanTween.scale(gameObject, Vector3.one * 0.1f, 1f).setEase(LeanTweenType.punch);
    }

    private void PopUpClose()
    {
        gameObject.SetActive(false);
        _goback.SetActive(false);
    }
}
