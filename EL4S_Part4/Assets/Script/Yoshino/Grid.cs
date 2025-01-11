using UnityEngine;
using UnityEngine.SceneManagement;

public class Grid : MonoBehaviour
{
    // シングルトンインスタンス
    public static Grid Instance { get; private set; }
    // グリッドの幅と高さ
    public static int width = 10;
    public static int height = 20;
    // グリッドを格納する2次元配列
    // public static Transform[,] grid;
    public static Transform[,] grid = new Transform[width, height];
    private const float lineOffset = -0.5f;
    public GameObject cubeBlock;

    public GameObject ScoreObject;

    GameObject Wall;

    [SerializeField] string NextScene = "Title";
    [SerializeField] float TransitionTime = 3f;

    bool GameOver = false;

    private void Start()
    {
        Wall = new GameObject("Wall"); 
        GameObject wall;
        // 横一列
        for (int i = 0; i < width; ++i)
        {
            wall = Instantiate(cubeBlock, new Vector3(i, -1.0f, 0), Quaternion.Euler(0, 0, 90)); // 90度回転
            wall.transform.parent = Wall.transform;
        }

        // 縦一列(左)
        for (int i = 0; i < height; ++i)
        {
            wall = Instantiate(cubeBlock, new Vector3(-1.0f, i - 1.0f, 0), Quaternion.identity);
            wall.transform.parent = Wall.transform;

        }
        // 縦一列(右)
        for (int i = 0; i < height; ++i)
        {
            wall = Instantiate(cubeBlock, new Vector3(width, i - 1.0f, 0), Quaternion.identity);
            wall.transform.parent = Wall.transform;

        }
        GameOver = false;

    }
    private void Awake()
    {
        // シングルトンのインスタンスが既に存在する場合はこのオブジェクトを破棄
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // インスタンスを設定し、DontDestroyOnLoadでシーン間で破棄されないようにする
            Instance = this;
            grid = new Transform[width, height];
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Grid.IsGameOver()) // ゲームオーバー条件のチェック
        {
            //GameOver = true;
            if(!GameOver)
            {
                Invoke(nameof(LoadNextScene), TransitionTime);
                GameOver = true;
            }
            //Debug.Log("Game Over!");
            // ゲームオーバー処理、例えばシーンをリロードするなど
        }
    }
    // このメソッドを Invoke で呼び出す
    public void LoadNextScene()
    {
        SceneManager.LoadScene(NextScene);
    }
    // ベクトルを整数に丸める
    public Vector2 RoundVector2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
    }
    // 指定された位置がグリッドの範囲内にあるかをチェック
    public bool InsideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 &&
                (int)pos.x < width &&
                (int)pos.y >= 0);
    }
    // 指定した行を削除
    public void DeleteRow(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    public void MathRow(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            ScoreObject.GetComponent<ScoreMath>().Add(grid[x, y].gameObject.GetComponent<MinoSuuji>().moji);            
        }
        ScoreObject.GetComponent<ScoreMath>().ScoreCalc();
    }

    public void DecreaseRow(int y)
    {
        for (int x = 0; x < width; ++x)
        {
            if (grid[x, y] != null)
            {
                // ブロックを一段下げる
                grid[x, y - 1] = grid[x, y];
                grid[x, y] = null;
                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }
    // 指定した行より上の行をすべて一段下げる
    public void DecreaseRowsAbove(int y)
    {
        for (int i = y; i < height; ++i)
            DecreaseRow(i);
    }
    // 行が完全に埋まっているかをチェック
    public bool IsRowFull(int y)
    {
        for (int x = 0; x < width; ++x)
            if (grid[x, y] == null)
                return false;
        return true;
    }
    // 完全に埋まった行を削除し、上の行を一段下げる
    public void DeleteFullRows()
    {
        for (int y = 0; y < height; ++y)
        {
            if (IsRowFull(y))
            {
                MathRow(y);
                DeleteRow(y);
                DecreaseRowsAbove(y + 1);
                GetComponent<AudioSource>().Play();                
                --y;

            }
        }
    }
    // グリッドの情報を更新
    public void UpdateGrid(Transform t)
    {
        for (int y = 0; y < height; ++y)
            for (int x = 0; x < width; ++x)
                if (grid[x, y] != null)
                    if (grid[x, y].parent == t)
                        grid[x, y] = null;

        foreach (Transform child in t)
        {
            Vector2 v = RoundVector2(child.position);
            grid[(int)v.x, (int)v.y] = child;
        }
    }
    // 境界線を描画するメソッドを追加
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // 左境界線
        Gizmos.DrawLine(new Vector3(lineOffset, lineOffset, 0), new Vector3(lineOffset, height + lineOffset, 0));
        // 右境界線
        Gizmos.DrawLine(new Vector3(width + lineOffset, lineOffset, 0), new Vector3(width + lineOffset, height + lineOffset, 0));
        // 下境界線
        Gizmos.DrawLine(new Vector3(lineOffset, lineOffset, 0), new Vector3(width + lineOffset, lineOffset, 0));
    }

        public static bool IsGameOver()
    {
        for (int x = 0; x < width; x++)
        {
            // グリッドの最上行にブロックが存在するかチェック
            if (grid[x, height - 1] != null)
            {
                return true; // ゲームオーバー条件を満たす
            }
        }
        return false;
    }
}