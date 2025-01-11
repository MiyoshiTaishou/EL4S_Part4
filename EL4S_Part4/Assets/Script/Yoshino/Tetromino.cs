using UnityEngine;

public class Tetromino : MonoBehaviour
{
    // 落下に関する時間の変数
    float fall = 0;
    [Tooltip("落下スピード")] public float fallSpeed = 1; // 落下速度
    [Tooltip("落下スピード(キー入力)")] public float fallSpeedKey = 1; // 落下速度

    [Tooltip("横移動スピード(キー入力)")] public float SideSpeedKey = 0.5f; // 落下速度
    float sidetime = 0;

   // [Tooltip("生成されてから回転できるまでの時間")] public float rotationtime = 1; // 落下速度
    //float rottime = 0f;

    bool KeyUp = true;
    [Tooltip("みのの最大縦幅")] public float minotate = 1; // 落下速度

    int downnum = 0;

    private void Start()
    {
        //rottime = Time.time;

    }

    void Update()
    {
        if (!Grid.IsGameOver()) // ゲームオーバー条件のチェック
            CheckUserInput();
    }
    // ユーザー入力をチェックしてブロックを移動または回転させる
    void CheckUserInput()
    {
        

        // 左矢印キーが押された場合
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            if (Time.time - sidetime >= SideSpeedKey || KeyUp)
            {
                // ブロックを左に移動
                transform.position += new Vector3(-1, 0, 0);
                // 位置が有効かチェック
                if (!IsValidGridPos())
                    transform.position += new Vector3(1, 0, 0); // 位置が無効なら元に戻す
                else
                    Grid.Instance.UpdateGrid(transform); // 位置が有効ならグリッドを更新
                
                sidetime = Time.time;
                KeyUp = false;
            }
        }
        // 右矢印キーが押された場合
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Time.time - sidetime >= SideSpeedKey || KeyUp)
            {
                // ブロックを右に移動
                transform.position += new Vector3(1, 0, 0);
                // 位置が有効かチェック
                if (!IsValidGridPos())
                    transform.position += new Vector3(-1, 0, 0); // 位置が無効なら元に戻す
                else
                    Grid.Instance.UpdateGrid(transform); // 位置が有効ならグリッドを更新

                sidetime = Time.time;
                KeyUp = false;
            }
        }
        else
        {
            KeyUp = true;
        }

        // 上矢印キーが押された場合
        if (Input.GetKeyDown(KeyCode.UpArrow) && /*Time.time - rottime >= rotationtime*/ downnum >= minotate)
        {
            // ブロックを回転
            transform.Rotate(0, 0, -90);
            // 位置が有効かチェック
            if (!IsValidGridPos())
                transform.Rotate(0, 0, 90); // 位置が無効なら元に戻す
            else
                Grid.Instance.UpdateGrid(transform); // 位置が有効ならグリッドを更新
        }
        if (Time.time - fall >= fallSpeed)
        {
            MinoDown();
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(Time.time - fall >= fallSpeedKey)
            {
                MinoDown();
            }
            
        }
    }

    void MinoDown()
    {
        downnum++;
        // ブロックを一段下に移動
        transform.position += new Vector3(0, -1f, 0);
        // 位置が有効かチェック
        if (!IsValidGridPos())
        {
            // 位置が無効なら元に戻す
            transform.position += new Vector3(0, 1f, 0);
            // グリッドを更新
            Grid.Instance.UpdateGrid(transform);
            // 完全に埋まった行を削除
            Grid.Instance.DeleteFullRows();
            // 新しいテトリミノを生成
            FindObjectOfType<Spawner>().SpawnNext();
            GetComponent<AudioSource>().Play();
            enabled = false;
        }
        else
        {
            Grid.Instance.UpdateGrid(transform);
        }
        // 落下時間をリセット
        fall = Time.time;
    }

    // グリッド内での位置が有効かどうかを判定する
    bool IsValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.Instance.RoundVector2(child.position);

            // グリッドの横範囲のみをチェックし、上部は無視する
            if (!Grid.Instance.InsideBorder(v))
            {
                if (v.y >= Grid.height) // 上のラインは無視
                    continue;

                return false; // それ以外は無効
            }

            // 上部のラインのグリッドは無視する
            if (v.y < Grid.height && Grid.grid[(int)v.x, (int)v.y] != null &&
                Grid.grid[(int)v.x, (int)v.y].parent != transform)
            {
                return false;
            }
        }
        return true;
    }


    void UpdateGrid()
    {
        for (int y = 0; y < Grid.height; ++y)
            for (int x = 0; x < Grid.width; ++x)
                if (Grid.grid[x, y] != null)
                    if (Grid.grid[x, y].parent == transform)
                        Grid.grid[x, y] = null;

        foreach (Transform child in transform)
        {
            Vector2 v = Grid.Instance.RoundVector2(child.position);
            Grid.grid[(int)v.x, (int)v.y] = child;
        }
    }
}