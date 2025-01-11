using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// RawImageをUVスクロールさせるクラス
/// </summary>
public class ScrollImage : MonoBehaviour
{
    private RawImage rawImage;

    [SerializeField, Header("スクロール速度"), Range(0.0f, 5.0f)]
    private float speed = 3.0f;

    private float offset; // UVスクロールのオフセット値

    // Start is called before the first frame update
    void Start()
    {
        rawImage = GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rawImage != null)
        {
            // オフセット値を増加させる
            offset += Time.deltaTime * speed;
            offset %= 1.0f; // 1.0fを超えたらリセットしてループする

            // uvRectのx座標をオフセットに基づいて更新
            var uvRect = rawImage.uvRect;
            uvRect.y = offset;
            rawImage.uvRect = uvRect;
        }
    }
}
