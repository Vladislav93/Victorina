using UnityEngine;
using System.Collections;

public class LeftArrow : MonoBehaviour
{

    [SerializeField] private UFSButton _button;

    public int Key;

    void Awake()
    {
        _button.Click += ExitMenu;
    }

    void OnDestroy()
    {
        _button.Click -= ExitMenu;
    }

    void Start()
    {
        gameObject.SetActive(false);
    }


    private void ExitMenu()
    {
        switch (Key)
        {
            case 0:
            {
                QuestionPuzzle.Instance.gameObject.SetActive(false);
                QuestionPuzzle.Instance.IDButton._iconsGO.SetActive(true);
                QuestionPuzzle.Instance.CurrentNumberOfQuest = 0;
                QuestionPuzzle.Instance.Mistake = false;
                QuestionPuzzle.Instance.Help = false;

                QuestionPuzzle.Instance._tempRightAnswList.Clear();
                BackgroundManager.Instance.Manager();

                QuestionPuzzle.Instance.ArrowsGameObject.SetActive(true);
                QuestionPuzzle.Instance.ArrowLeftGameObject.SetActive(false);
                    break;
            }
            case 1:
            {
                Application.LoadLevelAsync(1);
                    break;
            }
        }
    }
}
