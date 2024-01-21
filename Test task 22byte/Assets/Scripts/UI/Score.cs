using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMeshPro;

    [SerializeField]
    private GridPlacer _gridPlacer;

    private int _countMax = 0;
    private int _currentCount = 0;

    [HideInInspector]
    public int CurrentFruitNum = 1;

    private void Start()
    {
        GlobalEventManager.OnRetry += RetryScore;
        GlobalEventManager.OnGetFruit += GetFruit;
        RetryScore();
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnRetry -= RetryScore;
        GlobalEventManager.OnGetFruit -= GetFruit;
    }

    private void RetryScore()
    {
        _countMax = 0;
        _currentCount = 0;
        GlobalEventManager.SendOnGetCurrentMaxFruitCount(GetCountOfFruit());
        _textMeshPro.text = string.Format("0/{0}", GlobalData.CurrentMaxFruitCount);
    }

    private int GetCountOfFruit()
    {
        for (int i = 0; i < _gridPlacer.CurrentTileSetting.GetLength(0); i++)
        {
            for (int j = 0; j < _gridPlacer.CurrentTileSetting.GetLength(1); j++)
            {
                if (_gridPlacer.CurrentTileSetting[i, j] != 0)
                    _countMax++;
            }
        }
        return _countMax;
    }

    private void GetFruit(int num)
    {
        if (CurrentFruitNum != num)
        {
            GlobalEventManager.SendOnDeath();
        }
        else
        {
            _textMeshPro.text = string.Format("{0}/{1}", ++_currentCount, _countMax);
        }

        if (_currentCount == _countMax)
        {
            GlobalEventManager.SendOnWin(GlobalData.CurrentMaxFruitCount);
        }
    }

    public void ChangeCurrentFruitNum()
    {
        CurrentFruitNum = CurrentFruitNum == 1 ? 2 : 1; 
    }
}
