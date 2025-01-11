using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMesh;

    [SerializeField]
    string sceneName;

    [SerializeField]
    private AudioSource audioSource; // AudioSource ���C���X�y�N�^�[�Őݒ�

    private bool isSceneLoading = false; // �V�[���J�ڒ��̏d�����͖h�~�p�t���O

    // Start is called before the first frame update
    void Start()
    {
        SetScoreText(ScoreMath.total);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSceneLoading && Input.GetKeyDown(KeyCode.Space))
        {
            isSceneLoading = true;
            audioSource.Play();
            PressAnyKey();
        }
    }

    public void SetScoreText(float _score)
    {
        textMesh.text = _score.ToString();
    }

    void PressAnyKey()
    {
        StartCoroutine(SceneLoadAsync());
    }

    IEnumerator SceneLoadAsync()
    {
        // SE �̍Đ�����������̂�҂�
        yield return new WaitForSeconds(audioSource.clip.length);

        // �V�[����񓯊��Ń��[�h����
        var async = SceneManager.LoadSceneAsync(sceneName);

        // ���[�h����������܂őҋ@����
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
