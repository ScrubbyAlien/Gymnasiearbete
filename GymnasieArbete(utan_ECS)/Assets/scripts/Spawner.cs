using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject studentPrefab;
    GameObject newStudent;

    public int[] waveSizes;
    int wave;

    void Start()
    {
        wave = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnNextWave());
        }
    }

    IEnumerator SpawnNextWave()
    {
        if (wave < waveSizes.Length)
        {
            for (int i = 0; i < waveSizes[wave]; i++)
            {
                newStudent = Instantiate<GameObject>(studentPrefab);
                newStudent.transform.position = new Vector2(Random.Range(-8f, 8), Random.Range(-4f, 4f));
                yield return null;
            }
            wave += 1;
        }
    }
}
