using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InfectionParameters : MonoBehaviour
{
    public float lengthOfSide;

    public float maxSpeed;
    public float minSpeed;

    public float infectionRadius;
    [Range(0f, 1f)]
    public float infectionRate;
    public float timeTillRemoved;
    public float incubationTime;
    public int population;
    public int initiallyInfected;
    public float dayLength;
}

