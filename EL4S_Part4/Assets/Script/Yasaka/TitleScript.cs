using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    [SerializeField]
    private AudioSource audioSource; // AudioSource をインスペクターで設定

    private bool isSceneLoading = false; // シーン遷移中の重複入力防止用フラグ

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
