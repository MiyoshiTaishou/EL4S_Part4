using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using static System.TimeZoneInfo;

public class Spawner : MonoBehaviour
{
    public GameObject[] tetrominoes;
    [SerializeField] float TransitionTime = 3f;
    [SerializeField] string NextScene = "Result";
    [SerializeField] UnityEngine.UI.Text GameOverText;
    GameObject Nextmino;

    void Start()
    {
        int i = Random.Range(0, tetrominoes.Length);
        Instantiate(tetrominoes[i], transform.position, Quaternion.identity);

        Nextmino = Instantiate(tetrominoes[i], transform.GetChild(0).transform.position, Quaternion.identity);
        Nextmino.GetComponent<Tetromino>().enabled = false;
        Nextmino.transform.parent = transform.GetChild(0).transform;
        Debug.Log(Nextmino);

    }

    public void SpawnNext()
    {
        if (Grid.IsGameOver()) // ゲームオーバー条件のチェック
        {
            //GameOver = true;
            if (!Grid.GameOver)
            {
                Invoke(nameof(LoadNextScene), TransitionTime);
                Grid.GameOver = true;
            }
            GameOverText.gameObject.SetActive(true);

            Debug.Log("Game Over!");

            return;
            // ゲームオーバー処理、例えばシーンをリロードするなど
        }

        int i = Random.Range(0, tetrominoes.Length);

        Debug.Log(Nextmino);

        if(Nextmino.transform.parent)
            Nextmino.transform.parent =null;
        Nextmino.transform.position = transform.position;
        Nextmino.GetComponent<Tetromino>().enabled = true;

        Nextmino = Instantiate(tetrominoes[i], transform.GetChild(0).transform.position, Quaternion.identity);
        Nextmino.GetComponent<Tetromino>().enabled= false;
        Nextmino.transform.parent = transform.GetChild(0).transform;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(NextScene);
    }
}