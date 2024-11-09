using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class minotext : MonoBehaviour
{
    TextMeshPro text;
    MinoSuuji suji;
    // Start is called before the first frame update
    void Start()
    {
        text=GetComponent<TextMeshPro>();
        suji = transform.parent.GetComponent<MinoSuuji>();
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = suji.moji.ToString();
    }
}
