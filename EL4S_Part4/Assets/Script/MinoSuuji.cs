using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoSuuji : MonoBehaviour
{
    [SerializeField] public int moji;
    public int[] suuji = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public int[] kigo = { -1, -2, -3, -4 };
    // Start is called before the first frame update
    void Start()
    {
        int dochi = Random.Range(0, 2);
        if (dochi == 0) //”š‚ğ“ü‚ê‚é
        {
            int ransuu = Random.Range(0, suuji.Length);
            moji = suuji[ransuu];
        }
        else if (dochi == 1) //‹L†‚ğ“ü‚ê‚é
        {
            int ransuu = Random.Range(0, kigo.Length);
            moji= kigo[ransuu];
        }
        else
        {
            Debug.LogError("‚È‚¢‚æ"+dochi);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("‚à‚¶" + moji);
        int dochi = Random.Range(0, 2);
        if (dochi == 0) //”š‚ğ“ü‚ê‚é
        {
            int ransuu = Random.Range(0, suuji.Length);
            moji = suuji[ransuu];
        }
        else if (dochi == 1) //‹L†‚ğ“ü‚ê‚é
        {
            int ransuu = Random.Range(0, kigo.Length);
            moji = kigo[ransuu];
        }
        else
        {
            Debug.LogError("‚È‚¢‚æ" + dochi);
        }
    }
}
