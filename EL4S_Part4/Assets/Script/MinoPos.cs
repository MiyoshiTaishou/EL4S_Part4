using System.Collections.Generic;
using UnityEngine;

public class MinoPos : MonoBehaviour
{
    [SerializeField, Header("‰¡•")]public int SideMax;
    [SerializeField, Header("c•")]public int TateMax;
    [SerializeField, Header("‰¡ŒW”")]public float confX;
    [SerializeField, Header("cŒW”")] public float confY;

    [SerializeField]public List<List<bool>> pos;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<SideMax; i++) 
        {
            for(int j=0;j<TateMax;j++)
            {
                pos[i].Add(false);
            }
        }
        pos[SideMax / 2][TateMax] = true;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < SideMax; i++)
        {
            for (int j = 0; j < TateMax; j++)
            {
                if (pos[i][j])
                {
                    Vector3 pos=transform.position;
                    pos.x = i * confX;
                    pos.y = j * confY;
                    transform.position = pos;
                    return;
                }
            }
        }
    }
}
