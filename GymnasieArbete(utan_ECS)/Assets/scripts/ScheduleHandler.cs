using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScheduleHandler : MonoBehaviour
{
    public event Action<OnPeriodChangedEventArgs> onPeriodChange;

    Schedules.Schedule curSched = Schedules.schedules[0];
    Schedules.Period curPer;
    Schedules.Group[] atHome;
    Schedules.Group[] atSchool;
    float startTime;
    int periodIndex;

    void Start()
    {
        periodIndex = 0;
        curPer = curSched.periods[periodIndex];
        atHome = curPer.atHome;
        atSchool = curPer.atSchool;
        startTime = Time.time;
        SendEventOnPeriodChange();
    }

    void Update()
    {
        if (Time.time > startTime + curPer.period)
        {
            periodIndex = (periodIndex + 1) % curSched.periods.Length;
            curPer = curSched.periods[periodIndex];
            curPer = curSched.periods[periodIndex];
            atHome = curPer.atHome;
            atSchool = curPer.atSchool;
            startTime = Time.time;
            //send event to change period
            SendEventOnPeriodChange();
        }
    }

    void SendEventOnPeriodChange()
    {
        if (onPeriodChange != null)
        {
            List<Student.YearGroup> atHomeList = new List<Student.YearGroup> { };
            foreach (Schedules.Group s in atHome)
            {
                atHomeList.Add(s.yearGroup);
            }
            List<Student.YearGroup> atSchoolList = new List<Student.YearGroup> { };
            foreach (Schedules.Group s in atSchool)
            {
                atSchoolList.Add(s.yearGroup);
            }

            onPeriodChange(new OnPeriodChangedEventArgs
            {
                yearGroupsHome = atHomeList,
                yearGroupsToSchool = atSchoolList
            });
        }
    }

    public class OnPeriodChangedEventArgs : EventArgs
    {
        public List<Student.YearGroup> yearGroupsHome;
        public List<Student.YearGroup> yearGroupsToSchool;
    }
}

