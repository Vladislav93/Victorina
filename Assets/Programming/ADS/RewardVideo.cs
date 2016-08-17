using UnityEngine;
using System.Collections;
using System;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine.UI;

public class RewardVideo : MonoBehaviour, IRewardedVideoAdListener
{
    public UFSButton _button;

    public Text ButtonText;

  public HelpTablo _tablo;

    public Text _NextTimeReward;

    public GameObject _back;

    private bool flag = true;

    private bool flag2 = true;

    private bool flag3 = true;


   private string appKey = "9f5e868a694562d3c2331428a40d7ac8b1d52bb2302a503a";

    private void Awake()
    {
        _button.interactable = false;
        ButtonText.text = "Подсказки не готовы!\nПопробуй позже";
        _button.Click += RewardAction;
        Appodeal.initialize(appKey, Appodeal.REWARDED_VIDEO);
        Appodeal.setRewardedVideoCallbacks(this);

    }

    void Start()
    {
        if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
        {
            _button.interactable = true;

            ButtonText.text = "«Два ответа» БЕСПЛАТНО";
        }
    }

    private void OnDestroy()
    {
        _button.Click -= RewardAction;
        Appodeal.setRewardedVideoCallbacks(null);
    }

    private void RewardAction()
    {
        Appodeal.show(Appodeal.REWARDED_VIDEO);
    }

    public void onRewardedVideoLoaded()
    {
        _button.interactable = true;

        ButtonText.text = "«Два ответа» БЕСПЛАТНО";
    }

    public void onRewardedVideoFailedToLoad()
    {

      
    }

    public void onRewardedVideoShown()
    {
        
    }

    public void onRewardedVideoFinished(int amount, string name)
    {
        SaveAndLoad.SaveAllStarAndHelp(TwoAnswersHelp.Instance.Count + amount, 2);
        _tablo.SetTablo();
        _button.interactable = false;
        ButtonText.text = "Подсказки не готовы!\nПопробуй позже";
        Appodeal.setRewardedVideoCallbacks(null);
        Appodeal.setRewardedVideoCallbacks(this);
    }

    public void onRewardedVideoClosed()
    {

       // _back.SetActive(false);
    }
}
