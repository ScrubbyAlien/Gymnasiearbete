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
    [SerializeField] private Material material = null;

    private void Start()
    {
        //creates entity manager
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        //creates archetype and a list to hold entities
        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(Translation),
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(RenderBounds),
            typeof(MoveSpeedComponent),
            typeof(Scale)
            );

        NativeArray<Entity> entityArray = new NativeArray<Entity>(200, Allocator.Temp);
        entityManager.CreateEntity(entityArchetype, entityArray);

        //creates all the entities and adds them to the list, and also sets component values
        for (int i = 0; i < entityArray.Length; i++)
        {
            Entity entity = entityArray[i];

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

            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = mesh,
                material = material,
            });
        }

        entityArray.Dispose();
    }
}
