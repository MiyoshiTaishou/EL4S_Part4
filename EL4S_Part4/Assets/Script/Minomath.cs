using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Minomath : MonoBehaviour
{
    public int[,] apath;//Œ`‚ª“ü‚Á‚Ä‚é
    public int[,] suujikigoupath;

    public int[] suuji = {1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public int[] kigo = { -1, -2, -3, -4};

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<apath.GetLength(0);i++)
        {
            for(int j=0;j<apath.GetLength(1);j++)
            {
                var path = apath[i,j];
                if (path == 1)
                {
                    int dochi = Random.Range(0, 1);
                    if (dochi == 0) //”Žš‚ð“ü‚ê‚é
                    {
                        int ransuu = Random.Range(0, suuji.Length);
                        suujikigoupath[i, j] = suuji[ransuu];

                    }
                    else if (dochi == 1) //‹L†‚ð“ü‚ê‚é
                    {
                        int ransuu = Random.Range(0, kigo.Length);
                        suujikigoupath[i, j] = kigo[ransuu];
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < apath.GetLength(0); i++)
        {
            for (int j = 0; j < apath.GetLength(1); j++)
            {
                Debug.Log("‚ ‚ ‚ ‚ " + suujikigoupath[i,j]);
            }
        }
    }
}
