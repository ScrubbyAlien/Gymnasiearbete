using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Infected : MonoBehaviour
{

    public float radius;
    float checktime;
    float lastCheckTime;

    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        radius = 1f;
        checktime = Random.Range(2f, 5f);
        lastCheckTime = 3f;
    }

    void Update()
    {
        if (Time.time >= lastCheckTime + checktime)
        {
            Collider2D[] studentsWithinRadius = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (Collider2D s in studentsWithinRadius)
            {
                if (s.gameObject.tag == "Student")
                {
                    if (s.gameObject.HasComponent<Infected>() == false)
                    {
                        if (Random.Range(0f, 1f) <= 0.5f)
                        {
                            s.gameObject.AddComponent<Infected>();
                        }
                    }
                }
            }
            lastCheckTime = Time.time;
            checktime = Random.Range(2f, 5f);
        }

    }
}
