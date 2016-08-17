using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public int _minutes;

    [SerializeField]
    private float _seconds;

    [SerializeField]
    private Text _timer;

    private const float TimerUpdate = 0.1f;

    private bool flag=true;
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
       // StartCoroutine(TimerCourutin(_seconds));
    }

    public static Timer Instance { get; private set; }

    private IEnumerator TimerCourutin(float time)
    {
        float startTime = time;
        while (time > 0)
        {
            flag = true;
            if (time>9.5f)
                _timer.text = string.Format("{0}:{1:F0}", _minutes, time);
            else
            {
                _timer.text = string.Format("{0}:0{1:F0}", _minutes, time);
            }
            time -= TimerUpdate;
            yield return new WaitForSeconds(TimerUpdate);

        }

            _minutes--;
        if (_minutes >= 0)
        {
            StartTimerCoroutine();
        }

        else
        {

            LooseWinPopUp.Instance.Init(false);
        }
    }

    public void StartTimerCoroutine()
    {
        StartCoroutine(TimerCourutin(_seconds));
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }

}
