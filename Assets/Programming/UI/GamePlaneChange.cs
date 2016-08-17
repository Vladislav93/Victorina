using UnityEngine;
using System.Collections;
using System;

public class GamePlaneChange : MonoBehaviour {

    [SerializeField]
    private UFSButton _leftButton;

    [SerializeField]
    private UFSButton _rightButton;

    [SerializeField]
    private GameObject _green;

    [SerializeField]
    private GameObject _orange;

    [SerializeField]
    private GameObject _red;

    private int count;

    private float midX;
    private float midY;

    private bool _touchflag;

    void Start()
    { 
        midY = Screen.width / 2.0f;
    }
    void Awake()
    {
        _leftButton.Click += MoveLeft;
        _rightButton.Click += MoveRight;
    }

    void OnDestroy()
    {
        _leftButton.Click -= MoveLeft;
        _rightButton.Click -= MoveRight;
    }

    private void MoveRight()
    {
        if (count < 2)
        {
            
            switch (count)
            {
                case 0:
                    LeanTween.moveLocalX(_green, -800f, 0.1f).setDelay(0.1f);
                    LeanTween.moveLocalX(_orange, 1.050653f, 0.1f).setDelay(0.1f);
                    _rightButton.interactable = true;
                    _leftButton.interactable = true;
                    break;
                case 1:
                    LeanTween.moveLocalX(_orange, -800f, 0.1f).setDelay(0.1f);
                    LeanTween.moveLocalX(_red, 1.050653f, 0.1f).setDelay(0.1f);
                    _rightButton.interactable = false;
                    _leftButton.interactable = true;
                    break;

            }
            count++;
        }
        else
        {
            count = 2;
        }
        
    }

    private void MoveLeft()
    {
        if (count >= 0)
        {

            switch (count)
            {
                case 2:
                    LeanTween.moveLocalX(_red, 800f, 0.1f).setDelay(0.1f);
                    LeanTween.moveLocalX(_orange, 1.050653f, 0.1f).setDelay(0.1f);
                    _rightButton.interactable = true;
                    _leftButton.interactable = true;
                    count--;
                    break;
                case 1:
                    LeanTween.moveLocalX(_orange, 800f, 0.1f).setDelay(0.1f);
                    LeanTween.moveLocalX(_green, 1.050653f, 0.1f).setDelay(0.1f);
                    _rightButton.interactable = true;
                    _leftButton.interactable = true;
                    count--;
                    break;
                case 0:
                    //if(!_touchflag)
                        Application.LoadLevelAsync(1);
                    count--;
                    break;
            }
         
        }
        else
            count = 0;
        
    }

    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;

    void Update()
    {
        if (Input.touchCount > 0)

        {
            Touch touch = Input.touches[0];

            switch (touch.phase)

            {

                case TouchPhase.Began:

                    startPos = touch.position;
                    if (startPos.y < midY + 550f)
                        _touchflag = true;
                    else
                    {
                        _touchflag = false;
                    }
                         

                    break;

                case TouchPhase.Ended:

                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

                    if (swipeDistHorizontal > minSwipeDistX && _touchflag)

                    {

                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);

                        if (swipeValue > 0) //right swipe

                            MoveLeft();

                        else if (swipeValue < 0) //left swipe

                            MoveRight();

                    }
                    break;
            }
        }
    }
}
