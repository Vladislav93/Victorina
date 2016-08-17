using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerMarafon : MonoBehaviour
{

    public int _minutes;

    [SerializeField]
    private float _seconds;


    public Image _image;

    public float time;

    public Color GreenColor;

    public  float TimerUpdate = 0.1f;

    private bool flag=true;
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
       // StartCoroutine(TimerCourutin(_seconds));
    }

    public static TimerMarafon Instance { get; private set; }

    private IEnumerator TimerCourutin()
    {

        while (time > 0)
        {
            flag = true;

            time -= TimerUpdate;
               
                _image.fillAmount = 1 - (30 - time)/30;

            if (time > 10f && time <= 20f)
            {
                _image.color = Color.yellow;
            }
            else if (time > 20f && time <= 35f)
            {
                _image.color = GreenColor;
            }
            else
            {
                _image.color = Color.red;
            }

          yield return new WaitForSeconds(TimerUpdate);

        }
        //lose
        MarathonPopUp.Instance.Init();
        StopTimer();
    }

    public void StartTimerCoroutine()
    {
        time = _seconds;
        StartCoroutine(TimerCourutin());
    }

    public void StopTimer()
    {

        StopAllCoroutines();
    }

}
