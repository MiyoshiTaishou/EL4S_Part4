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
    private AudioSource audioSource; // AudioSource をインスペクターで設定

    [SerializeField]
    GameObject titleLogo, pressText, tutrialObj;

    STATE_TITLE state;

    private bool isSceneLoading = false; // シーン遷移中の重複入力防止用フラグ

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
                        Debug.LogError("タイトル画面のステートエラー　八坂");
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
        // SE の再生が完了するのを待つ
        yield return new WaitForSeconds(audioSource.clip.length);

        // シーンを非同期でロードする
        var async = SceneManager.LoadSceneAsync(sceneName);

        // ロードが完了するまで待機する
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
