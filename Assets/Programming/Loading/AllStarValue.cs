using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class AllStarValue : MonoBehaviour {

    public int Stars;
    public int Marathon;

    public string key;

    public bool flag ;
    public static AllStarValue Instance
    {
         get;
         private set;
    }

    void Init()
    {
        Instance = this;
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        Init();
        GetStars();
        GetMarathon();
        flag = true;

    }

    void OnDestroy()
    {
    }

    void GetStars()
    {

        Stars = SaveAndLoad.LoadAllStar();
    }

    public void SaveStars()
    {
       SaveAndLoad.SaveAllStarAndHelp(Stars,0);
    }

    void GetMarathon()
    {

        Marathon = SaveAndLoad.LoadMarathon();
    }

    public void SaveMarathon()
    {
        SaveAndLoad.SaveAllStarAndHelp(Marathon, 3);
    }
}
