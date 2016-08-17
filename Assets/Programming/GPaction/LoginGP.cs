using UnityEngine;
using GooglePlayGames;

public class LoginGP : MonoBehaviour {

   void Start()
    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool succses) =>
        {

        });

    }
}
