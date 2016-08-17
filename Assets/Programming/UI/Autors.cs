using UnityEngine;
using System.Collections;

public class Autors : MonoBehaviour {

    [SerializeField]
    private UFSButton _button;

    [SerializeField] private GameObject _go;
    void Awake()
    {
        _button.Click += Open;
    }



    void OnDestroy()
    {
        _button.Click -= Open;
      
    }

    private void Open()
    {
        _go.SetActive(true);
    }
}
