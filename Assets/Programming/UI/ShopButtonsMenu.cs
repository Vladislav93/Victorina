using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShopButtonsMenu : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        LeanTween.init(800);
        //LeanTween.scale(gameObject, Vector3.one * 0.01f, 1f).setEase(LeanTweenType.punch);
        gameObject.SetActive(false);
        
    }


}
