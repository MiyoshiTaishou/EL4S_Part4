using UnityEngine;

public class Board
{
    public const int Width = 10;
    public const int Height = 20;
    private int[,] grid;

    public GameObject[,] blockObjects; // ブロックのGameObject配列

    public void Initialize()
    {
        grid = new int[Height, Width];
        blockObjects = new GameObject[Height, Width];
        ClearBoard();
    }

    public int[,] GetGrid() => grid;

    public void ClearBoard()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                grid[y, x] = 0;
                if (blockObjects[y, x] != null)
                {
                    GameObject.Destroy(blockObjects[y, x]);
                    blockObjects[y, x] = null;
                }
            }
        }
    }

    public void DrawGrid()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (grid[y, x] == 1 && blockObjects[y, x] == null)
                {
                    // ブロックを表示する
                    GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    block.transform.position = new Vector3(x, Height - y, 0);
                    block.GetComponent<Renderer>().material.color = Color.cyan;
                    blockObjects[y, x] = block;
                }
            }
        }
    }

    public void PlaceBlock(int x, int y)
    {
        grid[y, x] = 1;
    }
}
