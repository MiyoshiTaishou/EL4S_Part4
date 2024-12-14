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

    // ������ǉ�
    public void Add(int _num)
    {
        sum.Add(_num);
    }

    // �X�R�A�v�Z
    public void ScoreCalc()
    {
        // �ϐ�������
        num.Clear();
        sign.Clear();
        total = 0;

        int currentNumber = 0;
        bool hasNumber = false;

        // �����Ɖ��Z�q�𕪗�
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
                sign.Add(-value); // ���Z�q��ǉ�
            }
        }

        // �Ō�̐�����ǉ�
        if (hasNumber)
        {
            num.Add(currentNumber);
        }

        // �|���Z�E����Z��D��v�Z
        for (int i = 0; i < sign.Count;)
        {
            if (sign[i] == 3 || sign[i] == 4) // 3: *, 4: /
            {
                if (i + 1 < num.Count)
                {
                    num[i] = sign[i] == 3 ? num[i] * num[i + 1] : num[i] / num[i + 1];
                    num.RemoveAt(i + 1);
                    sign.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            else
            {
                i++;
            }
        }

        // �����Z�E�����Z���v�Z
        total = num[0];
        for (int i = 0; i < sign.Count; i++)
        {
            total = sign[i] == 1 ? total + num[i + 1] : total - num[i + 1];
        }

        // �f�o�b�O���O
        Debug.Log("Score: " + total);
    }

    private void Update()
    {
        GetComponent<Text>().text = total.ToString();
    }
}
