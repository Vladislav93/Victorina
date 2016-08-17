using UnityEngine;
using System.Collections;

public class TwoAnswersHelp : MonoBehaviour {

    public int Count;

    public static TwoAnswersHelp Instance
    {
        get;
        private set;
    }

    private void Init()
    {
        Instance = this;
    }

    private void Awake()
    {
        Application.targetFrameRate = 50;
        Init();

    }

    private void Start()
    {
        SetCount();
    }

    public void SetCount()
    {
        Count = SaveAndLoad.LoadTwoAns();
    }

    public void SaveCount()
    {
        SaveAndLoad.SaveAllStarAndHelp(Count, 2);
    }

}
