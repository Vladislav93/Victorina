using UnityEngine;
using System.Collections;

public class StartLoad : MonoBehaviour {

    public int Level;
    void Awake()
    {
        Application.LoadLevelAsync(Level);
        PlayerPrefs.SetInt("rewardvideobutton", 1);
    }
}
