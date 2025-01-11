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
    private AudioSource audioSource; // AudioSource をインスペクターで設定

    private bool isSceneLoading = false; // シーン遷移中の重複入力防止用フラグ

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
