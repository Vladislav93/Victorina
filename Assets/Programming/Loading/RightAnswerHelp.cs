using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RightAnswerHelp : MonoBehaviour
{

    public int Count;

    [SerializeField] private Text _NextTimeReward;

    [SerializeField]
    private Text _FailedReward;

    public static RightAnswerHelp Instance
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
        Init();
        SetCount();
    }

    private void Start()
    {
        SetCount();
    }

    public void SetCount()
    {
        Count = SaveAndLoad.LoadAnsw();
    }

    public void SaveCount()
    {
        SaveAndLoad.SaveAllStarAndHelp(Count, 1);
    }
}
