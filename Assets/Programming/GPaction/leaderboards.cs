using UnityEngine;
using System.Collections;
using System;
using GooglePlayGames;

public class leaderboards : MonoBehaviour
{

   [SerializeField] private UFSButton _button;

    void Awake()
    {
        _button.Click += LeadGO;
    }

    private void LeadGO()
    {
        if (Social.localUser.authenticated)
        {
           Social.ReportScore(AllStarValue.Instance.Stars, GPConstant.leaderboard_stars_count, (bool success) =>
           {
               Social.ReportScore(AllStarValue.Instance.Marathon, GPConstant.leaderboard_marathon_count, (bool _success) => { });
               
               if (success)
                {
                    ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI();
                } 
            });
        }
    }

}
