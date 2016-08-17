using UnityEngine;
using System.Collections;

public class SaveAndLoadAtStart : MonoBehaviour {

    void Start()
    {
        SaveAndLoad.Load();
        SaveAndLoad.LoadAllStar();
        SaveAndLoad.LoadAnsw();
        SaveAndLoad.LoadTwoAns();
    }

    void OnDestroy()
    {
       // SaveAndLoad.Save();
    }

    void OnApplicationQuit()
    {
        //SaveAndLoad.Save();
        int sound = PlayerPrefs.GetInt("SoundOff");
        PlayerPrefs.DeleteAll();


        PlayerPrefs.SetInt("SoundOff", sound);
    }
}
