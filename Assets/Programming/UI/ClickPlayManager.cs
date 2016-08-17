using UnityEngine;
using System.Collections;

public class ClickPlayManager : MonoBehaviour {

public static ClickPlayManager Instance { get; private set; }
    public AudioSource Source;

    void Awake()
    {
        Instance = this;
    }

    public void playClick()
    {


    Source.Play();
    }
}
