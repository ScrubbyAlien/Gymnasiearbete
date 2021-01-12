using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectionParameters : MonoBehaviour
{
    public float lengthOfSide;

    public float maxSpeed;
    public float minSpeed;

    public float infectionRadius;
    [Range(0f, 1f)]
    public float infectionRate;
    public bool showInfectionRadius;

    public float timeTillRemoved;
    public float incubationTime;
    public int population;
    public int initiallyInfected;
    public float dayLength;

    public Slider infRate;
    public Text infRadius;
    public Toggle showInfRad;


    public void Update()
    {
        infectionRate = infRate.value;
        float n;
        if (float.TryParse(infRadius.text, out n))
        {
            infectionRadius = n;
        }
        else
        {
            infectionRadius = 1;
        }
        showInfectionRadius = showInfRad.isOn;
    }

}
