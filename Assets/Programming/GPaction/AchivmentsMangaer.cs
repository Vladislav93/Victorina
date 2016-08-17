using UnityEngine;


public static class AchivmentsMangaer {

public static void CheckAchivments()
    {
        int stars = AllStarValue.Instance.Stars;
        if (stars >= 10 && stars < 20)
            Social.ReportProgress(GPConstant.achievement_get_10_stars, 100.0f, (bool success) => {
                // handle success or failure
            });
        else
             if (stars >= 20 && stars < 30)
            Social.ReportProgress(GPConstant.achievement_get_20_stars, 100.0f, (bool success) => {
                // handle success or failure
            });
        else
             if (stars >= 30 && stars < 40)
            Social.ReportProgress(GPConstant.achievement_get_30_stars, 100.0f, (bool success) => {
                // handle success or failure
            });
        else
             if (stars >= 40 && stars < 50)
            Social.ReportProgress(GPConstant.achievement_get_40_stars, 100.0f, (bool success) => {
                // handle success or failure
            });
        else if (stars >= 50 && stars < 60)
        {

            Social.ReportProgress(GPConstant.achievement_get_50_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });
       }
        else if (stars >= 60 && stars < 70)
            Social.ReportProgress(GPConstant.achievement_get_60_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });
        else if (stars >= 70 && stars < 80)
            Social.ReportProgress(GPConstant.achievement_get_70_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });

        else if (stars >= 80 && stars < 90)
            Social.ReportProgress(GPConstant.achievement_get_80_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });

        else if (stars >= 90 && stars < 100)
            Social.ReportProgress(GPConstant.achievement_get_90_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });

        else if (stars >= 100 && stars < 110)
            Social.ReportProgress(GPConstant.achievement_get_100_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });


        else if (stars >= 110 && stars < 120)
            Social.ReportProgress(GPConstant.achievement_get_110_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });
        else if (stars >= 120 && stars < 130)
            Social.ReportProgress(GPConstant.achievement_get_120_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });
        else if (stars >= 130 && stars < 140)
            Social.ReportProgress(GPConstant.achievement_get_130_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });

        else if (stars >= 140 && stars < 150)
            Social.ReportProgress(GPConstant.achievement_get_140_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });

        else if (stars >= 150 && stars < 160)
            Social.ReportProgress(GPConstant.achievement_get_150_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });

        else if (stars >= 160 && stars < 170)
            Social.ReportProgress(GPConstant.achievement_get_160_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });

        else if (stars >= 170 && stars < 180)
            Social.ReportProgress(GPConstant.achievement_get_170_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });
        else if (stars >= 180)
            Social.ReportProgress(GPConstant.achievement_get_180_stars, 100.0f, (bool success) =>
            {
                // handle success or failure
            });
    }


}
