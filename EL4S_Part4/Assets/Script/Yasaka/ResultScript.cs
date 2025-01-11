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
        SetScoreText(ScoreMath.total);
    }

    // Update is called once per frame
    void Update()
    {
        // 全てのキーをチェックして離された瞬間を検出
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyUp(key))
            {
                PressAnyKey();
            }
        }

        //if (Input.anyKeyDown)
        //{
        //    PressAnyKey();
        //}
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
