using System.Collections.Generic;
using UnityEngine;

public class MinoPos : MonoBehaviour
{
    [SerializeField, Header("‰¡•")]public int SideMax;
    [SerializeField, Header("c•")]public int TateMax;
    [SerializeField, Header("‰¡ŒW”")]public float confX;
    [SerializeField, Header("cŒW”")] public float confY;

    [SerializeField,Header("ˆÊ’u")]public List<List<int>> pos;

    // Start is called before the first frame update
    void Start()
    {
        //for(int i=0; i<SideMax; i++) 
        //{
        //    for(int j=0;j<TateMax;j++)
        //    {
        //        pos[i,j]=0;
        //    }
        //}
        //pos[SideMax / 2,TateMax] = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < SideMax; i++)
        //{
        //    for (int j = 0; j < TateMax; j++)
        //    {
        //        if (pos[i, j] == 1)
        //        {
        //            Vector3 pos=transform.position;
        //            pos.x = i * confX;
        //            pos.y = j * confY;
        //            transform.position = pos;
        //            return;
        //        }
        //    }
        //}
    }
}
