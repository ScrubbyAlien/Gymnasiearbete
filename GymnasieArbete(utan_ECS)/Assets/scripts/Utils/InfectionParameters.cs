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

    [Range(0f, 1f)]
    public float attendence;

    public Slider infRate;
    public Text infRadius;
    public Toggle showInfRad;
    public Text daysTillRem;
    public Text incTime;
    public Text pop;
    public Text initInf;
    public Text dayLen;
    public Slider atten;
    public Text maxSp;
    public Text minSp;
    public Text len;

    public void Update()
    {
        //infection section
        infectionRate = infRate.value;
        infectionRadius = readValueFloat(infRadius, 1);
        showInfectionRadius = showInfRad.isOn;
        timeTillRemoved = readValueFloat(daysTillRem, 1) * dayLength;
        incubationTime = readValueFloat(incTime, 0) * dayLength;

        //simulation section
        population = readValueInt(pop, 1);
        initiallyInfected = readValueInt(initInf, 1);
        dayLength = readValueFloat(dayLen, 3);

        //student section
        attendence = atten.value;
        float typedMaxSpeed = readValueFloat(maxSp, 1);
        float typedMinSpeed = readValueFloat(minSp, 1);
        if (typedMaxSpeed >= typedMinSpeed)
        {
            maxSpeed = typedMaxSpeed;
            minSpeed = typedMinSpeed;
        }
        else
        {
            maxSpeed = 1;
            minSpeed = 1;
        }

        //mise section
        lengthOfSide = readValueFloat(len, 7.2f);

    }

    float readValueFloat(Text inputText, float def)
    {
        float n;
        if (float.TryParse(inputText.text, out n))
        {
            return n;
        }
        else
        {
            return def;
        }
    }

    int readValueInt(Text inputText, int def)
    {
        int n;
        if (int.TryParse(inputText.text, out n))
        {
            return n;
        }
        else
        {
            return def;
        }
    }

}
