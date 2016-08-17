using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HelpTablo : MonoBehaviour
{

    [SerializeField] private Text _text;

    void Start()
    {
        SetTablo();
    }

    public void SetTablo()
    {
        _text.text = String.Format("Два Ответа: {0}\nПравильный Ответ: {1}", SaveAndLoad.LoadTwoAns(), SaveAndLoad.LoadAnsw());
    }
}
