using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    [SerializeField]
    private AudioSource audioSource; // AudioSource ���C���X�y�N�^�[�Őݒ�

    private bool isSceneLoading = false; // �V�[���J�ڒ��̏d�����͖h�~�p�t���O

    // Update is called once per frame
    void Update()
    {
        if (!isSceneLoading && Input.anyKeyDown)
        {
            isSceneLoading = true;
            audioSource.Play();
            StartCoroutine(PlaySEAndLoadScene());
        }
    }

    IEnumerator PlaySEAndLoadScene()
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
