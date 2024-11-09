using UnityEngine;

public class Tetromino
{
    private int[,] shape;
    private Vector2Int position;
    private Board board;
    private int gridWidth = 10;
    private int gridHeight = 20;

    public Tetromino(int[,] shape, Vector2Int startPosition, Board board)
    {
        this.shape = shape;
        this.position = startPosition;
        this.board = board;
    }

    public bool MoveDown()
    {
        if (position.y < gridHeight - shape.GetLength(0))
        {
            position.y += 1;
            return true;
        }
        return false;
    }

    public void MoveLeft()
    {
        if (position.x > 0)
        {
            position.x -= 1;
        }
    }

    public void MoveRight()
    {
        if (position.x < gridWidth - shape.GetLength(1))
        {
            position.x += 1;
        }
    }

    public int[,] GetShape() => shape;
    public Vector2Int GetPosition() => position;
}
