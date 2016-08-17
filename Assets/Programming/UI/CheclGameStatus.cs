using UnityEngine;
using System.Collections;

public class CheclGameStatus : MonoBehaviour {

public static CheclGameStatus Instance { get; private set; }
    public bool flagGame = false;
    void Awake()
    {
        Instance = this;
    }
}
