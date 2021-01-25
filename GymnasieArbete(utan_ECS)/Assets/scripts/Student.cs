using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ComponentUtils;

public class Student : MonoBehaviour
{

    Transform border;
    public bool infected;

    public enum YearGroup
    {
        YearOne,
        YearTwo,
        YearThree
    }
    public YearGroup myYearGroup;

    void Start()
    {
        border = GameObject.FindGameObjectWithTag("Border").transform;
        FindObjectOfType<ScheduleHandler>().onPeriodChange += GoHome;
        FindObjectOfType<ScheduleHandler>().onPeriodChange += GoToSchool;
    }

    void Update()
    {
        infected = gameObject.HasComponent<Infected>() && !gameObject.HasComponent<Removed>();
    }

    public void GoHome(ScheduleHandler.OnPeriodChangedEventArgs args)
    {
        if (args.yearGroupsHome.Contains(myYearGroup))
        {
            transform.position = new Vector3(Random.Range(40, 80), Random.Range(40, 80), 0);
            gameObject.GetComponent<StudentMovement>().enabled = false;
            if (gameObject.HasComponent<Infected>())
            {
                gameObject.GetComponent<Infected>().enabled = false;
            }
        }
    }

    public void GoToSchool(ScheduleHandler.OnPeriodChangedEventArgs args)
    {
        if (args.yearGroupsToSchool.Contains(myYearGroup))
        {
            transform.position = new Vector3
                (
                    //Finds a random position inside the box
                    Random.Range(
                    border.position.x - (border.localScale.x - transform.localScale.x / 2),
                    border.position.x + (border.localScale.x - transform.localScale.x / 2)),
                    Random.Range(
                    border.position.y - (border.localScale.y - transform.localScale.y / 2),
                    border.position.y + (border.localScale.y - transform.localScale.y / 2))
                );
            gameObject.GetComponent<StudentMovement>().enabled = true;
            if (gameObject.HasComponent<Infected>())
            {
                gameObject.GetComponent<Infected>().enabled = true;
            }
        }
    }
}
