using UnityEngine;

public class GridPlacer : MonoBehaviour
{
    [SerializeField]
    private Tile _tilePrefub;

    public int[,] TileSetting = new int[,] {{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                              { 1, 0, 0, 0, 0, 0, 0, 1, 1, 0},
                                              { 1, 0, 0, 0, 0, 0, 0, 1, 1, 0},
                                              { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                              { 0, 2, 2, 2, 2, 0, 0, 0, 0, 0},
                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 2},
                                              { 0, 0, 0, 0, 0, 0, 0, 0, 2, 2},
                                              { 0, 0, 1, 1, 1, 1, 0, 2, 2, 2},};


    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < TileSetting.GetLength(0); x++)
        {
            for (int y = 0; y < TileSetting.GetLength(1); y++)
            {
                var spawnedTile = Instantiate(_tilePrefub,
                    new Vector3(transform.position.x + x, transform.position.y, transform.position.z + y),
                    Quaternion.FromToRotation(transform.forward, -1 * transform.up),
                    transform);
                spawnedTile.name = $"Tile({x},{y})";

                if ((x + y) % 2 == 0)
                    spawnedTile.Init(false, TileSetting[x, y]);
                else
                    spawnedTile.Init(true, TileSetting[x, y]);
            }
        }
    }
}
