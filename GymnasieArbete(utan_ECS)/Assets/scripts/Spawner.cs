using System.Collections;
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

    float yearOneRatio;
    float yearTwoRatio;
    float yearThreeRatio;

    void Start()
    {
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();
        studentT = studentPrefab.transform;
        yearOneRatio = 190f / 460;
        yearTwoRatio = 140f / 460;
        yearThreeRatio = 130f / 460;
    }

    void Update()
    {
        //hot keys for certain actions, should be moved to seperate script
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SpawnStudents();
        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    DestroyStudents();
        //}
    }

    public void SpawnStudents()
    {
        int numberYearOnes = (int)Mathf.Round(p.population * yearOneRatio);
        int numberYearTwos = numberYearOnes + (int)Mathf.Round(p.population * yearTwoRatio);
        int numberYearThrees = numberYearTwos + (int)Mathf.Round(p.population * yearThreeRatio);

        for (int i = 0; GameObject.FindGameObjectsWithTag("Student").Length < p.population; i++)
        {
            //instantiates new student from prefab and assigns transform, year group and parent
            newStudent = Instantiate<GameObject>(studentPrefab);
            float f = ScalingFactor(0.18f);
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

            //assigns year group based on ratios given by Henrik
            if (i <= numberYearOnes)
            {
                AssignYearGroup(Student.YearGroup.YearOne, newStudent);
            }
            else if (i <= numberYearTwos)
            {
                AssignYearGroup(Student.YearGroup.YearTwo, newStudent);
            }
            else
            {
                AssignYearGroup(Student.YearGroup.YearThree, newStudent);
            }
        }
    }

    void AssignYearGroup(Student.YearGroup yearGroup, GameObject student)
    {
        student.GetComponent<Student>().myYearGroup = yearGroup;
    }

    public void DestroyStudents()
    {
        GameObject[] students = GameObject.FindGameObjectsWithTag("Student");
        foreach (GameObject s in students)
        {
            Destroy(s);
        }
    }

    //the scaling factor is such that a measurement of 1 unit in the settings menu 
    //becomes 1 meter on the local scale of the students, also adjusts student size
    float ScalingFactor(float area)
    {
        return Mathf.Sqrt(area * 4 / Mathf.PI);
    }

}
