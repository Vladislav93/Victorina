using UnityEngine;
using System.Collections;

public class ShopButton : MonoBehaviour
{

    public UFSButton _button;

    public GameObject _gameObjectsMenu;

    public GameObject _gameObjectsShop;


    void Awake()
    {
        _button.Click += buttonAction;
    }

    void OnDestroy()
    {
        _button.Click -= buttonAction;
    }
    private void buttonAction()
    {
        _gameObjectsMenu.SetActive(false);
        _gameObjectsShop.SetActive(true);
        LeanTween.scale(_gameObjectsShop, Vector3.one * 0.1f, 1f).setEase(LeanTweenType.punch);
    }
}
