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

    public Text day;
    public Text infRateValue;
    public Text attendence;

    public Text curTSV;

    public Transform dayBar;

    public GameObject settingsMenu;
    public GameObject mainScreenUI;

    InfectionParameters p;

    void Update()
    {
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();

        //Text elements and daybar on main screen
        numberSusceptible.text = "Susceptible: " + GetStatCount("Sus").ToString();
        numberInfected.text = "Infected: " + GetStatCount("Inf").ToString();
        numberRemoved.text = "Removed: " + GetStatCount("Rem").ToString();
        density.text = "Density: " + (GetStatCount("All") / Mathf.Pow(p.lengthOfSide, 2)).ToString("0.00") +
        " people/sqrm";
        day.text = "Day: " + Mathf.FloorToInt(Time.time / p.dayLength);

        float pBarScaleF = 3.25f * (Time.time % p.dayLength) / p.dayLength;
        dayBar.localScale = new Vector3(pBarScaleF, dayBar.localScale.y, 1);

        curTSV.text = Time.timeScale.ToString("0.00") + "x";

        //text and values in settings menu
        infRateValue.text = p.infectionRate.ToString("0.00");
        attendence.text = p.attendence.ToString("0.00");
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


    bool settingsOpen = false;

    public void OpenSettingsMenu()
    {
        settingsOpen = !settingsOpen;
        settingsMenu.SetActive(settingsOpen);
        foreach (Button c in mainScreenUI.GetComponentsInChildren<Button>())
        {
            c.enabled = !settingsOpen;
        }
    }

}
