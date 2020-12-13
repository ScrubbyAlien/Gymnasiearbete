using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ComponentUtils;


public class Infector : MonoBehaviour
{
    int numberToInfect;

    InfectionParameters p;

    void Start()
    {
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();
    }

    void Update()
    {
        numberToInfect = p.initiallyInfected;
        if (Input.GetKeyDown(KeyCode.I))
        {
            Infect(numberToInfect);
        }
    }

    //Infects numberToInfect number of students the first time the i key is pressed
    void Infect(int n)
    {
        GameObject[] students = GameObject.FindGameObjectsWithTag("Student");

        if (numberToInfect < students.Length)
        {
            for (int i = 0; i < numberToInfect; i++)
            {
                if (students[i].HasComponent<Infected>() == false)
                {
                    students[i].AddComponent<Infected>();
                }
            }
        }
        else
        {
            Debug.Log("Can't infect that many students dummy");
        }

    }
}

