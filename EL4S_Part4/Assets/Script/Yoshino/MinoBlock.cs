using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoBlock : MonoBehaviour
{
    int[][] field;

    // Start is called before the first frame update
    void Start()
    {
        // 20行のジャグ配列（各行に個別の列を定義できる）
        field = new int[20][];

        // 各行に10列の配列を割り当てる
        for (int i = 0; i < field.Length; i++)
        {
            field[i] = new int[10];
        }

        // 各要素に初期値を設定する場合
        for (int i = 0; i < field.Length; i++)
        {
            for (int j = 0; j < field[i].Length; j++)
            {
                field[i][j] = 0; // ここで初期値を設定

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
