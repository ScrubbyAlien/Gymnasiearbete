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

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        radius = 1f;
        checktime = 3f;
        lastCheckTime = Time.time;
        timeOfInfection = Time.time;
        timeTillRemoved = 5f;
    }

    void Update()
    {
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
                            if (Random.Range(0f, 1f) <= 0.1f)
                            {
                                s.gameObject.AddComponent<Infected>();
                                break;
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
