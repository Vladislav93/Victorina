using UnityEngine;
using System.Collections;

public class GameStartButton : ShopButton {
    void Awake()
    {
        _button.Click += buttonAction;
    }

    void OnDestroy()
    {
        _button.Click -= buttonAction;
    }
    void Start()
    {
        if (CheclGameStatus.Instance.flagGame)
        {
            buttonAction();
        }
    }

    void buttonAction()
    {
        _gameObjectsMenu.SetActive(false);
        _gameObjectsShop.SetActive(true);
        LeanTween.scale(_gameObjectsShop, Vector3.one * 0.1f, 1f).setEase(LeanTweenType.punch);
        CheclGameStatus.Instance.flagGame = true;
    }
}
