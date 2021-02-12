using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logger : MonoBehaviour
{
    InfectionParameters p;

    public Text sus;
    public Text inf;
    public Text rem;

    public Text day;

    float lastCheck;
    float daysBetweenChecks;

    void Start()
    {
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();
        lastCheck = 0;
        daysBetweenChecks = 15;
    }

    void Update()
    {

        if (float.Parse(day.text.Split(' ')[1]) >= lastCheck + daysBetweenChecks)
        {
            Debug.Log(sus.text);
            Debug.Log(inf.text);
            Debug.Log(rem.text);
            Debug.Log(day.text);
            lastCheck += 15;
        }
    }

    public void ResetTimer()
    {
        lastCheck = 0;
    }

}
