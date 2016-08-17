using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class RightAnswer : MonoBehaviour
{

    [SerializeField]
    private UFSButton _button;

    private Color _color;
    void Awake()
    {
        _button.Click += RightAnsw;

    }

    void OnDestroy()
    {
        _button.Click -= RightAnsw;
    }

    private void RightAnsw()
    {
        if (RightAnswerHelp.Instance.Count > 0)
        {
            QuestionPuzzle.Instance.DisableGameObject.SetActive(true);
            _color.a = 255;
            _color.b = 0;
            _color.r = 0;
            _color.g = 0.7f;
            StartCoroutine(ColorCourutin(QuestionPuzzle.Instance.RightAnswImage, _color));
            QuestionPuzzle.Instance.RightAnswImage.color = Color.green;
            QuestionPuzzle.Instance.CurrentNumberOfQuest = QuestionPuzzle.Instance.CurrentNumberOfQuest + 1;
            _button.interactable = false;

            if (QuestionPuzzle.Instance.CurrentNumberOfQuest < QuestionPuzzle.Instance.IDButton.QuestionCapacity)
                Invoke("GetRandom", 1.2f);
            else
            {
                Invoke("Win", 1.2f);
                if (!QuestionPuzzle.Instance.Mistake && !QuestionPuzzle.Instance.Help)
                {

                    QuestionPuzzle.Instance.XMLSaveCurrentStatus(3);
                }
                else if ((!QuestionPuzzle.Instance.Mistake && QuestionPuzzle.Instance.Help) || (QuestionPuzzle.Instance.Mistake && !QuestionPuzzle.Instance.Help))
                {
                    QuestionPuzzle.Instance.XMLSaveCurrentStatus(2);
                }
                else if (QuestionPuzzle.Instance.Mistake && QuestionPuzzle.Instance.Help)
                {
                    QuestionPuzzle.Instance.XMLSaveCurrentStatus(1);
                }
            }
            RightAnswerHelp.Instance.Count = RightAnswerHelp.Instance.Count - 1;
            RightAnswerHelp.Instance.SaveCount();
        }
    }

    void GetRandom()
    {

            StopAllCoroutines();
            QuestionPuzzle.Instance.GetRandomQuestion();
            QuestionPuzzle.Instance.RightAnswImage.color = Color.white;

    }

    void Win()
    {
        AllStarValue.Instance.SaveStars();
        LooseWinPopUp.Instance.Init(true);
    }

    void OnEnable()
    {
        if (RightAnswerHelp.Instance.Count < 1)
        {
            _button.interactable = false;
        }
    }

    void OnDisable()
    {
        _button.interactable = true;
    }

    private static float TimerUpdate = 0.02f;

    private IEnumerator ColorCourutin(Image image, Color color)
    {
        if (color.g < 1)
            while (color.g < 1)
            {
                color.g = color.g + TimerUpdate;
                image.color = color;
                yield return new WaitForEndOfFrame();
            }
        else
        {
            while (color.g > 0.8f)
            {
                color.g = color.g - TimerUpdate;
                image.color = color;
                yield return new WaitForSeconds(TimerUpdate);
            }
        }
        StartCoroutine(ColorCourutin(image, color));
    }
}
