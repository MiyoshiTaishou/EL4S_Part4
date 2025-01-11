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

    // Start is called before the first frame update
    void Start()
    {
        //SetScoreText( ここにスコア変数を );
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
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
        var async = SceneManager.LoadSceneAsync(sceneName);

        // ロードが完了するまで待機する
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
