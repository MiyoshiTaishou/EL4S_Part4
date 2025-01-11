using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum STATE_TITLE
{
    TITLE, TUTRIAL
}

public class TitleScript : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    [SerializeField]
    private AudioSource audioSource; // AudioSource ���C���X�y�N�^�[�Őݒ�

    [SerializeField]
    GameObject titleLogo, pressText, tutrialObj;

    STATE_TITLE state;

    private bool isSceneLoading = false; // �V�[���J�ڒ��̏d�����͖h�~�p�t���O

    private void Start()
    {
        state = STATE_TITLE.TITLE;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyUp(key))
            {
                audioSource.Play();

                switch (state)
                {
                    case STATE_TITLE.TITLE:
                        tutrialObj.SetActive(true);

                        titleLogo.SetActive(false);
                        pressText.SetActive(false);

                        state = STATE_TITLE.TUTRIAL;
                        break;

                    case STATE_TITLE.TUTRIAL:
                        StartCoroutine(PlaySEAndLoadScene());
                        break;

                    default:
                        Debug.LogError("�^�C�g����ʂ̃X�e�[�g�G���[�@����");
                        break;
                }
                //StartCoroutine(PlaySEAndLoadScene());
            }
        }

       

        //if (!isSceneLoading && Input.anyKeyDown)
        //{
        //    isSceneLoading = true;
        //    audioSource.Play();
        //    StartCoroutine(PlaySEAndLoadScene());
        //}

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
