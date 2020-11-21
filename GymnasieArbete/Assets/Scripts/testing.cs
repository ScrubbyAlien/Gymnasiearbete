using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;

public class Testing : MonoBehaviour
{
    [SerializeField] private Mesh mesh = null;
    [SerializeField] private Material whiteMaterial = null;
    [SerializeField] private Material redMaterial = null;

    private void Start()
    {
        //creates entity manager
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        //creates archetype and a list to hold entities
        EntityArchetype StudentArchetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(RenderBounds),
            typeof(MoveSpeedComponent),
            typeof(Scale),
            typeof(StudentComponent)
            );

        NativeArray<Entity> susceptibleEntityArray = new NativeArray<Entity>(200, Allocator.Temp);
        entityManager.CreateEntity(StudentArchetype, susceptibleEntityArray);

        NativeArray<Entity> infectedEntityArray = new NativeArray<Entity>(1, Allocator.Temp);
        entityManager.CreateEntity(StudentArchetype, infectedEntityArray);

        //creates all the entities and adds them to the list, and also sets component values

        //creates the infected entities
        for (int i = 0; i < infectedEntityArray.Length; i++)
        {
            Entity entity = infectedEntityArray[i];

            //sets all componetn data
            {
                entityManager.SetComponentData(entity,
                    new MoveSpeedComponent
                    {
                        speed = 1.5f,
                        direction = new Vector2(1, 1),
                    });

                entityManager.SetComponentData(entity,
                    new Translation
                    {
                        Value = new Unity.Mathematics.float3(Random.Range(-7.5f, 7.5f), Random.Range(-7.5f, 7.5f), 0)
                    });

                entityManager.SetComponentData(entity,
                    new Scale
                    {
                        Value = 0.25f
                    });

                entityManager.SetComponentData(entity,
                    new StudentComponent
                    {
                        infectionState = StudentComponent.InfectionState.Infected
                    });

                entityManager.SetSharedComponentData(entity,
                    new RenderMesh
                    {
                        mesh = mesh,
                        material = redMaterial,
                    });
            }


        }

        //created the susceptible entities
        for (int i = 0; i < susceptibleEntityArray.Length; i++)
        {
            Entity entity = susceptibleEntityArray[i];

            //sets all componetn data
            {
                entityManager.SetComponentData(entity,
                    new MoveSpeedComponent
                    {
                        speed = 1.5f,
                        direction = new Vector2(1, 1),
                    });

                entityManager.SetComponentData(entity,
                    new Translation
                    {
                        Value = new Unity.Mathematics.float3(Random.Range(-7.5f, 7.5f), Random.Range(-7.5f, 7.5f), 0)
                    });

                entityManager.SetComponentData(entity,
                    new Scale
                    {
                        Value = 0.25f
                    });

                entityManager.SetComponentData(entity,
                    new StudentComponent
                    {
                        infectionState = StudentComponent.InfectionState.Susceptible
                    });

                entityManager.SetSharedComponentData(entity,
                    new RenderMesh
                    {
                        mesh = mesh,
                        material = whiteMaterial,
                    });
            }
        }

        susceptibleEntityArray.Dispose();
        infectedEntityArray.Dispose();
    }
}
