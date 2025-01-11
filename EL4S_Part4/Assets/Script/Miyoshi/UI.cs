using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// RawImage��UV�X�N���[��������N���X
/// </summary>
public class ScrollImage : MonoBehaviour
{
    private RawImage rawImage;

    [SerializeField, Header("�X�N���[�����x"), Range(0.0f, 5.0f)]
    private float speed = 3.0f;

    private float offset; // UV�X�N���[���̃I�t�Z�b�g�l

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
            // �I�t�Z�b�g�l�𑝉�������
            offset += Time.deltaTime * speed;
            offset %= 1.0f; // 1.0f�𒴂����烊�Z�b�g���ă��[�v����

            // uvRect��x���W���I�t�Z�b�g�Ɋ�Â��čX�V
            var uvRect = rawImage.uvRect;
            uvRect.y = offset;
            rawImage.uvRect = uvRect;
        }
    }
}
