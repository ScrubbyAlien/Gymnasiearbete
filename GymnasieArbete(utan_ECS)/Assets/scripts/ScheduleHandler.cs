using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleHandler : MonoBehaviour
{

    Schedules.Schedule curSched = Schedules.schedules[0];

    void Start()
    {
        int curPer = curSched.periods[0].period;
    }

    void Update()
    {

    }

}
