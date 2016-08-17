using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonsList : MonoBehaviour {

 public static ButtonsList Instance
    {
        get;
        private set;
    }

    private void Init()
    {
        Instance = this;
    }

    void Awake()
    {
        Init();
        
    }
    public List<ButtonAction> ButtonsListRepaint = new List<ButtonAction>();

    public void RePaint()
    {
        foreach(ButtonAction but in ButtonsListRepaint)
        {
            but.CheckCurrentStatus();
        }
    }
}
