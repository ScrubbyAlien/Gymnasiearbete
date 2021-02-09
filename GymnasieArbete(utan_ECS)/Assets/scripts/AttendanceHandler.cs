using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttendanceHandler : MonoBehaviour
{
    float lastCheck;
    float timeBetweenChecks;

    InfectionParameters p;

    void Start()
    {
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();
        lastCheck = Time.time;
        timeBetweenChecks = 7 * p.dayLength;
    }

    void Update()
    {
        if (Time.time >= lastCheck + timeBetweenChecks)
        {
            SendHomeSickStudents();
            lastCheck = Time.time;
        }
    }

    void SendHomeSickStudents()
    {
        GameObject[] students = GameObject.FindGameObjectsWithTag("Student");
        int length = Mathf.FloorToInt(students.Length * (1 - p.attendence));
        for (int i = 0; i < length; i++)
        {
            students[Random.Range(0, length - 1)].GetComponent<Student>().GoGomeAttendance();
        }
    }
}
