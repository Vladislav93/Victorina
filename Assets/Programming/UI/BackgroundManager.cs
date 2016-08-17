using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour
{

    public SpriteRenderer Background;

    public Sprite BackGreen;

    public Sprite BackOrange;

    public Sprite BackRed;

    public Sprite BackMenu;

    public GameObject First;

    public GameObject Second;

    public GameObject Third;

    public GameObject Fourth;

    public GameObject Fifth;

    public GameObject menu;

    public static BackgroundManager Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        Instance = this;
    }

    public void Manager(int lvl, int stroka)
    {
        First.SetActive(false);
        Second.SetActive(false);
        Third.SetActive(false);
        Fourth.SetActive(false);
        Fifth.SetActive(false);
        menu.SetActive(false);
        switch (lvl)
        {
            case 0:
                Background.sprite = BackGreen;
                break;
            case 1:
                Background.sprite = BackOrange;
                break;
            case 2:
                Background.sprite = BackRed;
                break;
        }

        switch (stroka)
        {
            case 0:
                First.SetActive(true);
                break;
            case 1:
                Second.SetActive(true);
                break;
            case 2:
                Third.SetActive(true);
                break;
            case 3:
                Fourth.SetActive(true);
                break;
            case 4:
                Fifth.SetActive(true);
                break;
        }
    }

    public void Manager()
    {
        First.SetActive(false);
        Second.SetActive(false);
        Third.SetActive(false);
        Fourth.SetActive(false);
        Fifth.SetActive(false);
        Background.sprite = BackMenu;
        menu.SetActive(true);
    }
}
