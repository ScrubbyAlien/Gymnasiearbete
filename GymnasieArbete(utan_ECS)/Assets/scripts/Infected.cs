using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ComponentUtils;

public class Infected : MonoBehaviour
{
    public float radius;
    float checktime;
    float lastCheckTime;
    float timeOfInfection;
    float timeTillRemoved;
    float incubationTime;
    float infectionrate;

    InfectionParameters p;
    Transform border;

    void Start()
    {
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();
        border = GameObject.FindGameObjectWithTag("border").gameObject.GetComponent<Transform>();
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        radius = (p.infectionRadius * border.localScale.x * 2) / p.lengthOfSide;
        checktime = p.dayLength;
        lastCheckTime = Time.time;
        timeOfInfection = Time.time;
        timeTillRemoved = p.timeTillRemoved;
        incubationTime = p.incubationTime;
    }

    void Update()
    {

        if (Time.time >= timeOfInfection + incubationTime && !gameObject.HasComponent<Removed>())
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }

        //If this object is not removed it will try to infect other objects within radius.
        //The objects within radius must not be removed or infected and have a percent chance every checkTime 
        //to get infected.
        if (!gameObject.HasComponent<Removed>())
        {
            if (Time.time >= lastCheckTime + checktime)
            {
                Collider2D[] studentsWithinRadius = Physics2D.OverlapCircleAll(transform.position, radius);
                foreach (Collider2D s in studentsWithinRadius)
                {
                    if (s.gameObject.tag == "Student")
                    {
                        if (!s.gameObject.HasComponent<Infected>() && !s.gameObject.HasComponent<Removed>())
                        {
                            if (Random.Range(0f, 1f) <= p.infectionRate)
                            {
                                s.gameObject.AddComponent<Infected>();
                            }
                        }
                    }
                }
                lastCheckTime = Time.time;
                checktime = 3f;
            }

            //After timeTillRemoved seconds this object will becomed removed
            if (Time.time >= timeOfInfection + timeTillRemoved)
            {
                gameObject.AddComponent<Removed>();
            }
        }


    }
}
