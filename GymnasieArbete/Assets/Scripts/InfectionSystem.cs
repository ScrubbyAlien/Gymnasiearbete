using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Rendering;

public class InfectionSystem : ComponentSystem
{

    Mesh mesh = Testing.GetInstance().mesh;
    Material redMaterial = Testing.GetInstance().redMaterial;

    protected override void OnUpdate()
    {
        Entities.ForEach((ref StudentComponent studentComponent, ref Entity entity) =>
        {
            if (studentComponent.infectionState == StudentComponent.InfectionState.Susceptible)
            {
                studentComponent.infectionState = StudentComponent.InfectionState.Infected;
            }

            if (studentComponent.infectionState == StudentComponent.InfectionState.Infected)
            {
                //Change the colour of the sprite to red
                EntityManager.RemoveComponent(entity, typeof(RenderMesh));
                EntityManager.AddComponent(entity, typeof(RenderMesh));
                EntityManager.SetSharedComponentData(entity,
                    new RenderMesh
                    {
                        mesh = mesh,
                        material = redMaterial
                    });
            }
        });
    }
}
