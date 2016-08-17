using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarsTablo : MonoBehaviour
{

    [SerializeField] private Text _text;

    void OnEnable()
    {
        _text.text = String.Format("{0}", AllStarValue.Instance.Stars);
    }
}
