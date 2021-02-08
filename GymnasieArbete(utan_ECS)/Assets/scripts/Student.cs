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

    InfectionParameters p;

    void Start()
    {
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();
        //subscribes methods to onPeriodChange event and finds reference to border from hierarchy
        border = GameObject.FindGameObjectWithTag("Border").transform;
        FindObjectOfType<ScheduleHandler>().onPeriodChange += GoHome;
        FindObjectOfType<ScheduleHandler>().onPeriodChange += GoToSchool;
    }

    void Update()
    {
        //displays if the student is infected and not removed for hover info later.
        infected = gameObject.HasComponent<Infected>() && !gameObject.HasComponent<Removed>();
    }

    public void GoHome(ScheduleHandler.OnPeriodChangedEventArgs args)
    {
        //checks if this year group should go home and if so moves it far away from the building
        //and disables present infection and movement components.
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

    public void GoGomeAttendance()
    {
        transform.position = new Vector3(Random.Range(40, 80), Random.Range(40, 80), 0);
        gameObject.GetComponent<StudentMovement>().enabled = false;
        if (gameObject.HasComponent<Infected>())
        {
            gameObject.GetComponent<Infected>().enabled = false;
        }
        Invoke("GoToSchoolAttendance", 7 * p.dayLength);
    }

    void GoToSchoolAttendance()
    {
        transform.position = new Vector3
                (
                    //Finds a random position inside the box
                    Random.Range
                    (
                        border.position.x - (border.localScale.x - transform.localScale.x / 2),
                        border.position.x + (border.localScale.x - transform.localScale.x / 2)
                    ),
                    Random.Range
                    (
                        border.position.y - (border.localScale.y - transform.localScale.y / 2),
                        border.position.y + (border.localScale.y - transform.localScale.y / 2)
                    )
                );
        gameObject.GetComponent<StudentMovement>().enabled = true;
        if (gameObject.HasComponent<Infected>())
        {
            gameObject.GetComponent<Infected>().enabled = true;
        }
    }

    public void GoToSchool(ScheduleHandler.OnPeriodChangedEventArgs args)
    {
        //checks if this year group should go to school and if so moves is back inside the border
        //of the building and reenables disabled components. 
        if (args.yearGroupsToSchool.Contains(myYearGroup))
        {
            transform.position = new Vector3
                (
                    //Finds a random position inside the box
                    Random.Range
                    (
                        border.position.x - (border.localScale.x - transform.localScale.x / 2),
                        border.position.x + (border.localScale.x - transform.localScale.x / 2)
                    ),
                    Random.Range
                    (
                        border.position.y - (border.localScale.y - transform.localScale.y / 2),
                        border.position.y + (border.localScale.y - transform.localScale.y / 2)
                    )
                );
            gameObject.GetComponent<StudentMovement>().enabled = true;
            if (gameObject.HasComponent<Infected>())
            {
                gameObject.GetComponent<Infected>().enabled = true;
            }
        }
    }

    void OnDisable()
    {
        FindObjectOfType<ScheduleHandler>().onPeriodChange -= GoHome;
        FindObjectOfType<ScheduleHandler>().onPeriodChange -= GoToSchool;
    }

    private void OnApplicationQuit()
    {
        MonoBehaviour[] scripts = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
            script.enabled = false;
    }
}
