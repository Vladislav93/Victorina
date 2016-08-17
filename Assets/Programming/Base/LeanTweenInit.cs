using UnityEngine;
using System.Collections;

public class LeanTweenInit : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        LeanTween.init();
    }

    void Start()
    {
        LeanTween.scale(gameObject, Vector3.one * 0.1f, 1f).setEase(LeanTweenType.punch);
    }


}
