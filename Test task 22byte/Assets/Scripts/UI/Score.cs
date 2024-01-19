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
        GlobalEventManager.OnGetFruit += GetFruit;
        _textMeshPro.text = string.Format("0/{0}", GetCountOfFruit());
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnGetFruit -= GetFruit;
    }

    private int GetCountOfFruit()
    {
        for (int i = 0; i < _gridPlacer.TileSetting.GetLength(0); i++)
        {
            for (int j = 0; j < _gridPlacer.TileSetting.GetLength(1); j++)
            {
                if (_gridPlacer.TileSetting[i, j] != 0)
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
            GlobalEventManager.SendOnWin();
        }
    }

    public void ChangeCurrentFruitNum()
    {
        CurrentFruitNum = CurrentFruitNum == 1 ? 2 : 1; 
    }
}
