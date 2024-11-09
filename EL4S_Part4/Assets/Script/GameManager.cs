using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Board board;
    private Tetromino currentTetromino;
    public UIManager uiManager; // UI �}�l�[�W���[�̎Q��

    private void Start()
    {
        board = new Board();
        board.Initialize();
        SpawnNewTetromino();
    }

    private void Update()
    {
        if (currentTetromino == null) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow)) currentTetromino.MoveLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow)) currentTetromino.MoveRight();
        if (Input.GetKeyDown(KeyCode.DownArrow)) currentTetromino.MoveDown();

        // �`��̍X�V
        uiManager.DrawTetromino(currentTetromino.GetShape(), currentTetromino.GetPosition());
    }

    private void SpawnNewTetromino()
    {
        int[,] tShape = new int[,]
        {
            {0, 1, 0},
            {1, 1, 1},
            {0, 0, 0}
        };
        Vector2Int startPosition = new Vector2Int(4, 0);
        currentTetromino = new Tetromino(tShape, startPosition, board);
    }
}
