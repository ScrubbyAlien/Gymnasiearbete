using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Rendering;

public class InfectionSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref StudentComponent studentComponent) =>
        {
            if (studentComponent.infectionState == StudentComponent.InfectionState.Susceptible)
            {
                studentComponent.infectionState = StudentComponent.InfectionState.Infected;
            }

            if (studentComponent.infectionState == StudentComponent.InfectionState.Infected)
            {
                //Change the colour of the sprite to red

            }
        });
    }
}
