using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 全てのキーをチェックして離された瞬間を検出
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyUp(key))
            {
                StartCoroutine(SceneLoadAsync());
            }
        }

        //if (Input.anyKeyDown)
        //{
        //    StartCoroutine(SceneLoadAsync());
        //}       
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
