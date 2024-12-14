using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMath : MonoBehaviour
{
    public List<int> sum = new List<int>();
    public List<int> sign = new List<int>(); // 1: +, 2: -, 3: *, 4: /
    public List<int> num = new List<int>();
    public int total = 0;

    // 数字を追加
    public void Add(int _num)
    {
        sum.Add(_num);
    }

    // スコア計算
    public void ScoreCalc()
    {
        // 変数初期化
        num.Clear();
        sign.Clear();
        total = 0;

        int currentNumber = 0;
        bool hasNumber = false;

        // 数字と演算子を分類
        foreach (int value in sum)
        {
            if (value >= 0)
            {
                currentNumber = currentNumber * 10 + value;
                hasNumber = true;
            }
            else
            {
                if (hasNumber)
                {
                    num.Add(currentNumber);
                    currentNumber = 0;
                    hasNumber = false;
                }
                sign.Add(-value); // 演算子を追加
            }
        }

        // 最後の数字を追加
        if (hasNumber)
        {
            num.Add(currentNumber);
        }

        // 掛け算・割り算を優先計算
        for (int i = 0; i < sign.Count;)
        {
            if (sign[i] == 3 || sign[i] == 4) // 3: *, 4: /
            {
                if (i + 1 < num.Count) // インデックス範囲チェック
                {
                    if (sign[i] == 4 && num[i + 1] == 0) // ゼロ除算チェック
                    {
                        Debug.LogError("Division by zero detected!");
                        return;
                    }

                    // 掛け算・割り算の計算
                    num[i] = sign[i] == 3 ? num[i] * num[i + 1] : num[i] / num[i + 1];
                    num.RemoveAt(i + 1);
                    sign.RemoveAt(i);
                }
                else
                {
                    Debug.LogError($"Invalid expression detected during multiplication/division. i: {i}, num.Count: {num.Count}, sign.Count: {sign.Count}");
                    return;
                }
            }
            else
            {
                i++;
            }
        }

        // 足し算・引き算を計算
        if (num.Count > 0)
        {
            total = num[0];
            for (int i = 0; i < sign.Count; i++)
            {
                if (i + 1 < num.Count) // インデックス範囲チェック
                {
                    total = sign[i] == 1 ? total + num[i + 1] : total - num[i + 1];
                }
                else
                {
                    Debug.LogError($"Invalid expression detected during addition/subtraction. i: {i}, num.Count: {num.Count}, sign.Count: {sign.Count}");
                    return;
                }
            }
        }
        else
        {
            Debug.LogError("No numbers available for calculation.");
            return;
        }



        // デバッグログ
        Debug.Log("Score: " + total);
    }

    private void Update()
    {
        Text textComponent = GetComponent<Text>();
        if (textComponent != null)
        {
            textComponent.text = total.ToString();
        }
        else
        {
            Debug.LogError("Text component not found on the GameObject.");
        }
    }
}
