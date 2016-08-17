using UnityEngine;
using System.Collections;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class ADSManager : MonoBehaviour
{

    private string appKey = "9f5e868a694562d3c2331428a40d7ac8b1d52bb2302a503a";

    private bool flag;

    private void Awake()
    {
        flag = true;
        Appodeal.initialize(appKey, Appodeal.BANNER_TOP);
    }

    private void Update()
    {
        if (Appodeal.isLoaded(Appodeal.BANNER_TOP) && flag)
        {
            flag = false;
            ShowADS();
        }
    }

    private void ShowADS()
    {
        Appodeal.show(Appodeal.BANNER_TOP);
    }
}

