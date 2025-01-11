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
        if (Input.anyKeyDown)
        {
            StartCoroutine(SceneLoadAsync());
        }       
    }

    IEnumerator SceneLoadAsync()
    {
        var async = SceneManager.LoadSceneAsync(sceneName);

        // ÉçÅ[ÉhÇ™äÆóπÇ∑ÇÈÇ‹Ç≈ë“ã@Ç∑ÇÈ
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
