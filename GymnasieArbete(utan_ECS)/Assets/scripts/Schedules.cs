using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Schedules
{
    public class Group
    {
        public Student.YearGroup yearGroup;
        public int size;
    }

    public class Period
    {
        public int period;
        public Group[] atSchool;
        public Group[] atHome;
    }

    public class Schedule
    {
        public int ScheduleID;
        public Period[] periods;
    }

    static Group yearOne = new Group()
    {
        yearGroup = Student.YearGroup.YearOne,
        size = 190
    };
    static Group yearTwo = new Group()
    {
        yearGroup = Student.YearGroup.YearTwo,
        size = 140
    };
    static Group yearThree = new Group()
    {
        yearGroup = Student.YearGroup.YearThree,
        size = 130
    };

    //one year group one week at a time, other two home
    static Schedule schedulel1 = new Schedule()
    {
        periods = new Period[]
        {
            new Period()
            {
                period = 7,
                atSchool = new Group[]{yearOne},
                atHome = new Group[]{yearTwo, yearThree}
            },
            new Period()
            {
                period = 7,
                atSchool = new Group[]{yearTwo},
                atHome = new Group[]{yearOne, yearThree}
            },
            new Period()
            {
                period = 7,
                atSchool = new Group[]{yearThree},
                atHome = new Group[]{yearOne, yearTwo}
            }
        }
    };

    //two year groups one week at a time, other one home, cycle year groups
    static Schedule schedulel2 = new Schedule()
    {
        periods = new Period[]
        {
            new Period()
            {
                period = 7,
                atSchool = new Group[]{yearOne, yearTwo},
                atHome = new Group[]{yearThree}
            },
            new Period()
            {
                period = 7,
                atSchool = new Group[]{yearTwo, yearThree},
                atHome = new Group[]{yearOne}
            },
            new Period()
            {
                period = 7,
                atSchool = new Group[]{yearThree, yearOne},
                atHome = new Group[]{yearTwo}
            }
        }
    };

    public static Schedule[] schedules = new Schedule[] { schedulel1, schedulel2 };

}

