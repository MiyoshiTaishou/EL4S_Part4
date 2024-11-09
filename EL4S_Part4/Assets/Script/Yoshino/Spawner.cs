using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] tetrominoes;

    GameObject Nextmino;

    void Start()
    {
        int i = Random.Range(0, tetrominoes.Length);
        Instantiate(tetrominoes[i], transform.position, Quaternion.identity);

        Nextmino = Instantiate(tetrominoes[i], transform.GetChild(0).transform.position, Quaternion.identity);
        Nextmino.GetComponent<Tetromino>().enabled = false;
        Nextmino.transform.parent = transform.GetChild(0).transform;

    }

    public void SpawnNext()
    {
        int i = Random.Range(0, tetrominoes.Length);

        if(Nextmino.transform.parent)
            Nextmino.transform.parent =null;
        Nextmino.transform.position = transform.position;
        Nextmino.GetComponent<Tetromino>().enabled = true;

        Nextmino = Instantiate(tetrominoes[i], transform.GetChild(0).transform.position, Quaternion.identity);
        Nextmino.GetComponent<Tetromino>().enabled= false;
        Nextmino.transform.parent = transform.GetChild(0).transform;
    }
}