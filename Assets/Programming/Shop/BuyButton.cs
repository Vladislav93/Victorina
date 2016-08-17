using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using UnityEngine.UI;
using OnePF;
using System;

public class BuyButton : MonoBehaviour {

    [SerializeField]
    private UFSButton _button;

    [SerializeField]
    private string SKU;

    public int CountPlus;

    [SerializeField] private HelpTablo _helpTablo;

    private string keyPurch = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAkaBsqR00u2Bdsak8/KuOjT8EYMY54fntUCs37iq55STC0Lua48idSdM4ynCQp3AvKWx6C2RMnqv3mJeiso7DGQd1hAP4HovP2J0OlA6iMc/VvzLsJSeSyU76vV7o50tocZj7VfPx90eYhkAciVaUh8WqKSXChZOxykTXblio/ahbE0W4zT6rGvJsPzzFf1wFVm//teRMRBIdERFx0J/HRtmGo5dFWp6w6jcfNj+CYj1QemXXhb2XlOUP40qFBYP1Xwxt85w96i2v8p03AXb61LrswKGhVMsjAaRopKSu36KudmPA+0uacDXwozL7ikKlbtp9cnqH5BGCffnobKXimwIDAQAB";

    void Awake()
    {
        OpenIABEventManager.purchaseSucceededEvent += OnPurchaseSucceded;
        _button.Click += ShowAds;
       
        OpenIAB.mapSku(SKU, OpenIAB_Android.STORE_GOOGLE, SKU);
        var options = new OnePF.Options();
        options.storeKeys.Add(OpenIAB_Android.STORE_GOOGLE, keyPurch);
        OpenIAB.init(options);
    }


    private void OnPurchaseSucceded(Purchase obj)
    {
        if (obj.Sku == SKU)
        {
            RightAnswerHelp.Instance.Count = RightAnswerHelp.Instance.Count + CountPlus;
            SaveAndLoad.SaveAllStarAndHelp(RightAnswerHelp.Instance.Count,1);
            _helpTablo.SetTablo();
        }

        OpenIAB.consumeProduct(obj);
    }


    void OnDestroy()
    {
        OpenIABEventManager.purchaseSucceededEvent -= OnPurchaseSucceded;
        _button.Click -= ShowAds;
    }
    private void ShowAds()
    {
        OpenIAB.purchaseProduct(SKU);
    }

}
