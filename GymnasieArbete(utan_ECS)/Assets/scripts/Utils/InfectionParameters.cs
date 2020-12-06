using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//use FindObjectofType() to get reference to this script instead of using namespace stuff 

public class InfectionParameters : MonoBehaviour
{
    //not done
    public float maxSpeed;
    public float minSpeed;

    //not done
    public float infectionRadius;
    [Range(0f, 1f)] public float infectionRate;
    public float timeTillremoved;
}

