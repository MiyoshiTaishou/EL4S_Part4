using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public GameObject blockPrefab; // ブロックのプレハブ
    public Transform canvasTransform; // Canvas の Transform
    public int gridWidth = 10; // 横幅
    public int gridHeight = 20; // 縦幅
    public GameObject linePrefab; // グリッド線のプレハブ

    private List<GameObject> currentBlocks = new List<GameObject>();
    private List<GameObject> gridLines = new List<GameObject>();

    // スタート時にグリッド線を描画
    private void Start()
    {
        DrawGridLines();
    }

    // グリッド線を描画
    private void DrawGridLines()
    {
        float cellSize = 32f; // 1マスのサイズ

        // 縦のグリッド線
        for (int x = 0; x <= gridWidth; x++)
        {
            GameObject line = Instantiate(linePrefab, canvasTransform);
            RectTransform rectTransform = line.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(2, gridHeight * cellSize);
            rectTransform.anchoredPosition = new Vector2(x * cellSize, -(gridHeight * cellSize) / 2);
            gridLines.Add(line);
        }

        // 横のグリッド線
        for (int y = 0; y <= gridHeight; y++)
        {
            GameObject line = Instantiate(linePrefab, canvasTransform);
            RectTransform rectTransform = line.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(gridWidth * cellSize, 2);
            rectTransform.anchoredPosition = new Vector2((gridWidth * cellSize) / 2, -y * cellSize);
            gridLines.Add(line);
        }
    }

    // ミノの描画
    public void DrawTetromino(int[,] shape, Vector2Int position)
    {
        ClearBlocks();

        for (int y = 0; y < shape.GetLength(0); y++)
        {
            for (int x = 0; x < shape.GetLength(1); x++)
            {
                if (shape[y, x] == 1)
                {
                    GameObject block = Instantiate(blockPrefab, canvasTransform);
                    RectTransform rectTransform = block.GetComponent<RectTransform>();
                    rectTransform.anchoredPosition = new Vector2(
                        (position.x + x) * 32,
                        -(position.y + y) * 32
                    );
                    currentBlocks.Add(block);
                }
            }
        }
    }

    private void ClearBlocks()
    {
        foreach (GameObject block in currentBlocks)
        {
            Destroy(block);
        }
        currentBlocks.Clear();
    }
}
