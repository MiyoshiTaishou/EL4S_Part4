using UnityEngine;

public class Tetromino : MonoBehaviour
{
    // �����Ɋւ��鎞�Ԃ̕ϐ�
    float fall = 0;
    [Tooltip("�����X�s�[�h")] public float fallSpeed = 1; // �������x
    [Tooltip("�����X�s�[�h(�L�[����)")] public float fallSpeedKey = 1; // �������x

    [Tooltip("���ړ��X�s�[�h(�L�[����)")] public float SideSpeedKey = 0.5f; // �������x
    float sidetime = 0;

   // [Tooltip("��������Ă����]�ł���܂ł̎���")] public float rotationtime = 1; // �������x
    //float rottime = 0f;

    bool KeyUp = true;
    [Tooltip("�݂̂̍ő�c��")] public float minotate = 1; // �������x

    int downnum = 0;

    private void Start()
    {
        //rottime = Time.time;

    }

    void Update()
    {
        if (!Grid.IsGameOver()) // �Q�[���I�[�o�[�����̃`�F�b�N
            CheckUserInput();
    }
    // ���[�U�[���͂��`�F�b�N���ău���b�N���ړ��܂��͉�]������
    void CheckUserInput()
    {
        

        // �����L�[�������ꂽ�ꍇ
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            if (Time.time - sidetime >= SideSpeedKey || KeyUp)
            {
                // �u���b�N�����Ɉړ�
                transform.position += new Vector3(-1, 0, 0);
                // �ʒu���L�����`�F�b�N
                if (!IsValidGridPos())
                    transform.position += new Vector3(1, 0, 0); // �ʒu�������Ȃ猳�ɖ߂�
                else
                    Grid.Instance.UpdateGrid(transform); // �ʒu���L���Ȃ�O���b�h���X�V
                
                sidetime = Time.time;
                KeyUp = false;
            }
        }
        // �E���L�[�������ꂽ�ꍇ
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Time.time - sidetime >= SideSpeedKey || KeyUp)
            {
                // �u���b�N���E�Ɉړ�
                transform.position += new Vector3(1, 0, 0);
                // �ʒu���L�����`�F�b�N
                if (!IsValidGridPos())
                    transform.position += new Vector3(-1, 0, 0); // �ʒu�������Ȃ猳�ɖ߂�
                else
                    Grid.Instance.UpdateGrid(transform); // �ʒu���L���Ȃ�O���b�h���X�V

                sidetime = Time.time;
                KeyUp = false;
            }
        }
        else
        {
            KeyUp = true;
        }

        // ����L�[�������ꂽ�ꍇ
        if (Input.GetKeyDown(KeyCode.UpArrow) && /*Time.time - rottime >= rotationtime*/ downnum >= minotate)
        {
            // �u���b�N����]
            transform.Rotate(0, 0, -90);
            // �ʒu���L�����`�F�b�N
            if (!IsValidGridPos())
                transform.Rotate(0, 0, 90); // �ʒu�������Ȃ猳�ɖ߂�
            else
                Grid.Instance.UpdateGrid(transform); // �ʒu���L���Ȃ�O���b�h���X�V
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
        // �u���b�N����i���Ɉړ�
        transform.position += new Vector3(0, -1f, 0);
        // �ʒu���L�����`�F�b�N
        if (!IsValidGridPos())
        {
            // �ʒu�������Ȃ猳�ɖ߂�
            transform.position += new Vector3(0, 1f, 0);
            // �O���b�h���X�V
            Grid.Instance.UpdateGrid(transform);
            // ���S�ɖ��܂����s���폜
            Grid.Instance.DeleteFullRows();
            // �V�����e�g���~�m�𐶐�
            FindObjectOfType<Spawner>().SpawnNext();
            GetComponent<AudioSource>().Play();
            enabled = false;
        }
        else
        {
            Grid.Instance.UpdateGrid(transform);
        }
        // �������Ԃ����Z�b�g
        fall = Time.time;
    }

    // �O���b�h���ł̈ʒu���L�����ǂ����𔻒肷��
    bool IsValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 v = Grid.Instance.RoundVector2(child.position);

            // �O���b�h�̉��͈݂͂̂��`�F�b�N���A�㕔�͖�������
            if (!Grid.Instance.InsideBorder(v))
            {
                if (v.y >= Grid.height) // ��̃��C���͖���
                    continue;

                return false; // ����ȊO�͖���
            }

            // �㕔�̃��C���̃O���b�h�͖�������
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