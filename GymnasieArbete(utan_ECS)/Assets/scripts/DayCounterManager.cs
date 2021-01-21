using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCounterManager : MonoBehaviour
{
    public Text day;
    public Transform dayBar;

    bool counterOn;
    float startTime;

    InfectionParameters p;

    void Start()
    {
        counterOn = false;
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();
        day.text = "Day: 0";
        dayBar.localScale = new Vector3(0, dayBar.localScale.y, 1);
    }

    void Update()
    {
        if (counterOn)
        {
            float pBarScaleF;
            if (p.dayLength == 0)
            {
                pBarScaleF = 0;
            }
            else
            {
                pBarScaleF = 3.25f * ((Time.time - startTime) % p.dayLength) / p.dayLength;
            }

            dayBar.localScale = new Vector3(pBarScaleF, dayBar.localScale.y, 1);

            day.text = "Day: " + Mathf.FloorToInt((Time.time - startTime) / p.dayLength);
        }
    }

    public void StartCounter()
    {
        counterOn = true;
        startTime = Time.time;
    }

    public void StopCounter()
    {
        counterOn = false;
        dayBar.localScale = new Vector3(0, dayBar.localScale.y, 1);
        day.text = "Day: 0";
    }

}
