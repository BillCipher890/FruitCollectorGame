using System.Collections;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMeshPro;

    private (int seconds, int minutes)[] levelsTime = new (int seconds, int minutes)[] 
    { (seconds: 30, minutes: 1), (seconds: 20, minutes: 1), (seconds: 10, minutes: 1)};

    private int _seconds = 30;
    private int _minutes = 1;

    private Coroutine _timerCoroutine;

    void Start()
    {
        GlobalEventManager.OnDeath += StopTimer;
        GlobalEventManager.OnWin += StopTimer;
        GlobalEventManager.OnRetry += RetryTimer;

        _seconds = levelsTime[0].seconds;
        _minutes = levelsTime[0].minutes;

        _timerCoroutine = StartCoroutine(SecTimer());
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnDeath += StopTimer;
        GlobalEventManager.OnWin += StopTimer;
        GlobalEventManager.OnRetry += RetryTimer;
    }

    public void StopTimer(int money)
    {
        StopCoroutine(_timerCoroutine);
    }

    public void StopTimer()
    {
        StopCoroutine(_timerCoroutine);
    }

    public void RetryTimer()
    {
        _seconds = levelsTime[GlobalData.CurrentLevel].seconds;
        _minutes = levelsTime[GlobalData.CurrentLevel].minutes;

        _timerCoroutine = StartCoroutine(SecTimer());
    }

    IEnumerator SecTimer()
    {
        while (true)
        {
            if (_seconds >= 10)
            {
                _textMeshPro.text = string.Format("{0}:{1}", _minutes.ToString(), _seconds.ToString());
                yield return new WaitForSeconds(1);
            }
            else if (_seconds >= 0)
            {
                _textMeshPro.text = string.Format("{0}:0{1}", _minutes.ToString(), _seconds.ToString());
                yield return new WaitForSeconds(1);
            }
            else if (_minutes > 0)
            {
                _minutes -= 1;
                _seconds += 60;
                _textMeshPro.text = string.Format("{0}:{1}", _minutes.ToString(), _seconds.ToString());
                yield return new WaitForSeconds(1);
            }
            else if (_minutes == 0 && _seconds < 0)
            {
                break;
            }
            _seconds -= 1;
        }
    }
}
