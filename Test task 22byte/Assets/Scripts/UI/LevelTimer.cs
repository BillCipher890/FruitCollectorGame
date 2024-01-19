using System.Collections;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMeshPro;

    private int _seconds = 30;
    private int _minutes = 1;
    void Start()
    {
        StartCoroutine(SecTimer());
    }

    IEnumerator SecTimer()
    {
        while (true)
        {
            _seconds -= 1;
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
        }
    }
}
