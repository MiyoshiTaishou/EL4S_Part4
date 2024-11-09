using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMath : MonoBehaviour
{
    private List<int> sum = new List<int>();
    private List<int> sign = new List<int>();
    private List<int> num = new List<int>();
    int signnum=-1;
    public int total=0;
    int tyokuzenn = 0;
    private int Score;
    int numnum=-1;
    
    public void Add(int _num)
    {
        sum.Add(_num);
    }

    public void ScoreCalc()
    {
        for (int i = 0; i < sum.Count; i++)
        {
            if (sum[i] > 0 && num.Count==0||tyokuzenn==-1)
            {
                num.Add(sum[i]);
                tyokuzenn = 1;
                numnum++;
            }
            else if (sum[i]>0)
            {
                num[numnum] *= 10;
                num[numnum] += sum[i];
                tyokuzenn = 1;
            }
            switch (sum[i])
            {
                //ë´ÇµéZ
                case -1:
                    
                    if(tyokuzenn==1)
                    {
                        sign.Add(1);
                        signnum++;
                        break;
                    }
                    tyokuzenn = -1;
                    break;
                //à¯Ç´éZ
                case -2:
                    if (tyokuzenn == 1)
                    {
                        sign.Add(2);
                        signnum++;
                        break;
                    }
                    tyokuzenn = -1;


                    if (sign[signnum] == 1)
                    {
                        sign[signnum] = 2;
                        break;
                    }
                    else if (sign[signnum] == 2)
                    {
                        sign[signnum] = 1; 
                        break;
                    }
                    else if (sign[signnum] == 3)
                    {
                        sign[signnum] = 4;
                        break;
                    }
                    else if (sign[signnum] == 4)
                    {
                        sign[signnum] = 3;
                        break;
                    }
                    else if (sign[signnum] == 5)
                    {
                        sign[signnum] = 6;
                        break;
                    }
                    else if (sign[signnum] == 6)
                    {
                        sign[signnum] = 5;
                        break;
                    }
                    break;
                //ä|ÇØéZ
                case -3:
                    if (tyokuzenn == 1)
                    {
                        sign.Add(3);
                        signnum++;
                        break;
                    }
                    tyokuzenn = -1;

                    if (sign[signnum] == 1)
                    {
                        sign[signnum] = 3;
                        break;
                    }
                    else if (sign[signnum] == 2)
                    {
                        sign[signnum] = 4;
                        break;
                    }
                    else if (sign[signnum] == 5)
                    {
                        sign[signnum] = 1;
                        break;
                    }
                    else if (sign[signnum] == 6)
                    {
                        sign[signnum] = 2;
                        break;
                    }

                    break;
            Å@Å@//äÑÇËéZ
                case -4:
                    if (tyokuzenn == 1)
                    {
                        sign.Add(5);
                        signnum++;
                        break;
                    }
                    tyokuzenn = -1;

                    if (sign[signnum] == 1)
                    {
                        sign[signnum] = 5;
                        break;
                    }
                    else if (sign[signnum] == 2)
                    {
                        sign[signnum] = 6;
                        break;
                    }
                    else if (sign[signnum] == 3)
                    {
                        sign[signnum] = 1;
                        break;
                    }
                    else if (sign[signnum] == 4)
                    {
                        sign[signnum] = 2;
                        break;
                    }

                    break;
            }
        }
        for(int i=0;i<sign.Count;i++)
        {
            if (sign[i] >= 3)
            {
                switch (sign[i]) 
                {
                    case 3:
                        num[i+1]=num[i] * num[i + 1];
                        num.Remove(i);
                        sign.Remove(i);
                        break;
                    case 4:
                        num[i + 1] = num[i] * -num[i + 1];
                        num.Remove(i);
                        sign.Remove(i);
                        break;
                    case 5:
                        num[i + 1] = num[i] / num[i + 1];
                        num.Remove(i);
                        sign.Remove(i);
                        break;
                    case 6:
                        num[i + 1] = num[i] / -num[i + 1];
                        num.Remove(i);
                        sign.Remove(i);
                        break;
                }
            }
            if (num.Count == 1)
            {
                total += num[0];
            }
        }
        for (int i = 0; i < sign.Count; i++)
        {
            switch (sign[i])
            {
                case 1:
                    num[i + 1] = num[i] + num[i + 1];
                    num.Remove(i);
                    sign.Remove(i);
                    break;
                case 2:
                    num[i + 1] = num[i] - num[i + 1];
                    num.Remove(i);
                    sign.Remove(i);
                    break;
            }
            if (num.Count == 1)
            {
                numnum = 0;
                signnum = 0;
                tyokuzenn = 0;

                total += num[0];
            }
        }

    }

    private void Update()
    {
        GetComponent<Text>().text = total.ToString();
    }
}
