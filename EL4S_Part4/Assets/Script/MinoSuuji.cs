using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinoSuuji : MonoBehaviour
{
    [SerializeField] public int moji;
    public int[] suuji = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public int[] kigo = { -1, -2, -3, -4 };
    // Start is called before the first frame update
    void Start()
    {
        int dochi = Random.Range(0, 2);
        if (dochi == 0) //数字を入れる
        {
            int ransuu = Random.Range(0, suuji.Length);
            moji = suuji[ransuu];
        }
        else if (dochi == 1) //記号を入れる
        {
            int ransuu = Random.Range(0, kigo.Length);
            moji= kigo[ransuu];
        }
        else
        {
            Debug.LogError("ないよ"+dochi);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("もじ" + moji);
        //int dochi = Random.Range(0, 2);
        //if (dochi == 0) //数字を入れる
        //{
        //    int ransuu = Random.Range(0, suuji.Length);
        //    moji = suuji[ransuu];
        //}
        //else if (dochi == 1) //記号を入れる
        //{
        //    int ransuu = Random.Range(0, kigo.Length);
        //    moji = kigo[ransuu];
        //}
        //else
        //{
        //    Debug.LogError("ないよ" + dochi);
        //}
    }
}
