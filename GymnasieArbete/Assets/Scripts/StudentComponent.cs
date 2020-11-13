using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public struct StudentComponent : IComponentData
{
    public enum InfectionState
    {
        Susceptible,
        Infected,
        Removed
    }

    public InfectionState infectionState;
}
