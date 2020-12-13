using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{

    public Text numberSusceptible;
    public Text numberInfected;
    public Text numberRemoved;
    public Text density;

    InfectionParameters p;

    void Update()
    {
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();
        numberSusceptible.text = "Susceptible: " + GetStatCount("Sus").ToString();
        numberInfected.text = "Infected: " + GetStatCount("Inf").ToString();
        numberRemoved.text = "Removed: " + GetStatCount("Rem").ToString();
        density.text = "Density: " + (GetStatCount("All") / Mathf.Pow(p.lengthOfSide, 2)).ToString("#.##") +
        " people/sqrm";
    }

    int GetStatCount(string studentType)
    {
        int numStudents = GameObject.FindGameObjectsWithTag("Student").Length;
        int numInfected = GameObject.FindObjectsOfType<Infected>().Length;
        int numberRemoved = GameObject.FindObjectsOfType<Removed>().Length;
        if (studentType == "Sus")
        {
            return numStudents - numInfected;
        }
        else if (studentType == "Inf")
        {
            return numInfected - numberRemoved;
        }
        else if (studentType == "Rem")
        {
            return numberRemoved;
        }
        else if (studentType == "All")
        {
            return numStudents;
        }
        else
        {
            return -1;
        }
    }
}
