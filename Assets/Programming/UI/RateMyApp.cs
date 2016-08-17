using UnityEngine;
using System.Collections;

public class RateMyApp : MonoBehaviour {

    public UFSButton _buttonRate;
    public UFSButton _buttonDislike;

    void Awake()
    {
        _buttonRate.Click += Rate;
        _buttonDislike.Click += Close;
        Close();
    }

    void Start()
    {
        LeanTween.scale(gameObject, Vector3.one * 0.1f, 1f).setEase(LeanTweenType.punch);
    }
    void OnDestroy()
    {
        _buttonRate.Click -= Rate;
        _buttonDislike.Click -= Close;
    }

    private void Close()
    {
        Destroy(gameObject);
    }

    private void Rate()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.TwentyOneGames.MozgaMozg");
        Destroy(gameObject);
    }
}
