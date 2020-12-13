using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject studentPrefab;
    GameObject newStudent;

    int pop;

    public Transform border;
    Transform studentT;

    InfectionParameters p;
    void Start()
    {
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();
        studentT = studentPrefab.transform;
        pop = p.population;
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
        for (int i = 0; i < pop; i++)
        {
            newStudent = Instantiate<GameObject>(studentPrefab);
            newStudent.transform.position = new Vector2
                (
                    Random.Range(
                    border.position.x - (border.localScale.x - studentT.localScale.x / 2),
                    border.position.x + (border.localScale.x - studentT.localScale.x / 2)),
                    Random.Range(
                    border.position.y - (border.localScale.y - studentT.localScale.y / 2),
                    border.position.y + (border.localScale.y - studentT.localScale.y / 2))
                );
            float f = ScalingFactor(0.12f);
            float s = border.localScale.x * 2 * f / p.lengthOfSide;
            newStudent.transform.localScale = new Vector3(s, s, 1);
            newStudent.transform.parent = transform;
            yield return null;
        }
    }

    float ScalingFactor(float area)
    {
        return Mathf.Sqrt(area * 4 / Mathf.PI);
    }
}
