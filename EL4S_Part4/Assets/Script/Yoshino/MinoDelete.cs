using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoDelete : MonoBehaviour
{
    int width = 0;  //����
    int SideNumber =0;  //���̂��鐔��
    int SideTotalNumber = 0;�@//���v

    int[][] field;

    

    // Start is called before the first frame update
    void Start() 
    {
        // 20�s�̃W���O�z��i�e�s�Ɍʂ̗���`�ł���j
        field = new int[20][];

        // �e�s��10��̔z������蓖�Ă�
        for (int i = 0; i < field.Length; i++)
        {
            field[i] = new int[10];
        }

        // �e�v�f�ɏ����l��ݒ肷��ꍇ
        for (int i = 0; i < field.Length; i++)
        {
            for (int j = 0; j < field[i].Length; j++)
            {
                field[i][j] = 0; // �����ŏ����l��ݒ�

            }
        }


    }

    // Update is called once per frame
    void Update()
    {


    }

    public void ChangeMark(int[][] _field)
    {
        //�������t�B�[���h�̒�̍�����擾���Ă���


        //


    }

}
