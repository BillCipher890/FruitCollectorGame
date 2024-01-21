using UnityEngine;

public class GridPlacer : MonoBehaviour
{
    [SerializeField]
    private Tile _tilePrefub;
    public int[,] CurrentTileSetting;

    private int[,] _tileSettingLevel1 = new int[,] {{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 1, 0, 0, 0, 0, 0, 0, 1, 1, 0},
                                                    { 1, 0, 0, 0, 0, 0, 0, 1, 1, 0},
                                                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 2, 2, 2, 2, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
                                                    { 0, 0, 0, 0, 0, 0, 0, 0, 2, 2},
                                                    { 0, 0, 1, 1, 1, 1, 0, 2, 2, 2}};

    private int[,] _tileSettingLevel2 = new int[,] {{ 2, 0, 2, 0, 0, 0, 0, 0, 0, 0},
                                                    { 2, 2, 2, 0, 0, 0, 0, 2, 1, 0},
                                                    { 2, 0, 2, 0, 0, 0, 0, 1, 2, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 2, 1, 0},
                                                    { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 1, 1, 1, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0},
                                                    { 0, 0, 0, 2, 2, 0, 0, 1, 1, 1},
                                                    { 1, 1, 1, 2, 2, 0, 0, 0, 1, 1}};

    private int[,] _tileSettingLevel3 = new int[,] {{ 1, 1, 1, 1, 0, 0, 1, 1, 1, 0},
                                                    { 1, 0, 1, 0, 0, 0, 0, 1, 0, 0},
                                                    { 1, 1, 0, 0, 0, 0, 0, 1, 0, 0},
                                                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                                    { 0, 0, 0, 0, 2, 2, 2, 0, 0, 0},
                                                    { 0, 0, 0, 0, 0, 0, 2, 0, 0, 0},
                                                    { 0, 2, 2, 0, 0, 0, 2, 0, 0, 0},
                                                    { 0, 0, 2, 0, 0, 0, 0, 0, 0, 0},
                                                    { 2, 2, 2, 0, 1, 1, 0, 0, 0, 1},
                                                    { 2, 0, 0, 0, 1, 1, 0, 0, 1, 1}};

    private int[][,] _tileSettings;

    

    private void Start()
    {
        GlobalEventManager.OnRetry += OnRetry;

        _tileSettings = new int[][,] { _tileSettingLevel1, _tileSettingLevel2, _tileSettingLevel3 };
        CurrentTileSetting = _tileSettings[GlobalData.CurrentLevel];
        GenerateGrid();
    }

    private void OnDestroy()
    {
        GlobalEventManager.OnRetry -= OnRetry;
    }

    public void GenerateGrid()
    {
        for (int y = 0; y < CurrentTileSetting.GetLength(0); y++)
        {
            for (int x = 0; x < CurrentTileSetting.GetLength(1); x++)
            {
                var spawnedTile = Instantiate(_tilePrefub,
                    new Vector3(transform.position.x + x, transform.position.y, transform.position.z + y),
                    Quaternion.FromToRotation(transform.forward, -1 * transform.up),
                    transform);
                spawnedTile.name = $"Tile({x},{y})";

                if ((x + y) % 2 == 0)
                    spawnedTile.Init(false, CurrentTileSetting[x, y]);
                else
                    spawnedTile.Init(true, CurrentTileSetting[x, y]);
            }
        }
    }

    public void DisactivateGrid()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void OnRetry()
    {
        CurrentTileSetting = _tileSettings[GlobalData.CurrentLevel];
        DisactivateGrid();
        GenerateGrid();
    }
}
