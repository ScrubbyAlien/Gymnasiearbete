﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject studentPrefab;
    Transform studentT;
    GameObject newStudent;

    int pop;

    public Transform border;

    InfectionParameters p;

    void Start()
    {
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();
        studentT = studentPrefab.transform;
    }

    void Update()
    {
        //hot keys for certain actions, should be moved to seperate script
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnStudents();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            DestroyStudents();
        }
    }

    public void SpawnStudents()
    {
        while (GameObject.FindGameObjectsWithTag("Student").Length < p.population)
        {
            //instantiates new student from prefab and assigns transform, year group and parent
            newStudent = Instantiate<GameObject>(studentPrefab);
            float f = ScalingFactor(0.12f);
            float s = border.localScale.x * 2 * f / p.lengthOfSide;
            newStudent.transform.localScale = new Vector3(s, s, 1);
            newStudent.transform.position = new Vector2
                (
                    //Finds a random position inside the box
                    Random.Range(
                    border.position.x - (border.localScale.x - studentT.localScale.x / 2),
                    border.position.x + (border.localScale.x - studentT.localScale.x / 2)),
                    Random.Range(
                    border.position.y - (border.localScale.y - studentT.localScale.y / 2),
                    border.position.y + (border.localScale.y - studentT.localScale.y / 2))
                );
            newStudent.transform.parent = transform;
            newStudent.GetComponent<Student>().myYearGroup = (Student.YearGroup)Random.Range(0, 3);
        }
    }

    public void DestroyStudents()
    {
        GameObject[] students = GameObject.FindGameObjectsWithTag("Student");
        foreach (GameObject s in students)
        {
            Destroy(s);
        }
    }

    //the scaling factor such that a measure ment of 1 unit in the settings menu 
    //becomes 1 meter on the local scale of the students, also adjusts student size
    float ScalingFactor(float area)
    {
        return Mathf.Sqrt(area * 4 / Mathf.PI);
    }

}
