using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class MoverSystem : ComponentSystem
{
    private float dpf;

    protected override void OnUpdate()
    {

        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent, ref Scale scale) =>
        {
            dpf = moveSpeedComponent.speed * Time.DeltaTime;

            //Percent chance every frame that the entity will change it's speed
            if (UnityEngine.Random.Range(0f, 1f) < chancePerSecond(0.3f, Time.DeltaTime))
            {
                moveSpeedComponent.direction.y = moveSpeedComponent.direction.normalized.y;
                moveSpeedComponent.direction.x = moveSpeedComponent.direction.normalized.x;

                moveSpeedComponent.direction += new Vector2(
                    UnityEngine.Random.Range(-1f, 1f),
                    UnityEngine.Random.Range(-1f, 1f)
                );

            }

            //Percent chance every frame that the entity will change it's speed
            if (UnityEngine.Random.Range(0f, 1f) < chancePerSecond(0.3f, Time.DeltaTime))
            {
                moveSpeedComponent.speed = UnityEngine.Random.Range(0.5f, 3f);
            }

            translation.Value.x += moveSpeedComponent.direction.normalized.x * dpf;
            translation.Value.y += moveSpeedComponent.direction.normalized.y * dpf;

            //Handles bouncing on the walls
            {
                if (translation.Value.y > 5f - scale.Value / 2)
                {
                    moveSpeedComponent.direction.y = -math.abs(moveSpeedComponent.direction.y);
                }

                if (translation.Value.y < -(5f - scale.Value / 2))
                {
                    moveSpeedComponent.direction.y = math.abs(moveSpeedComponent.direction.y);
                }

                if (translation.Value.x > 8f - scale.Value / 2)
                {
                    moveSpeedComponent.direction.x = -math.abs(moveSpeedComponent.direction.x);
                }

                if (translation.Value.x < -(8f - scale.Value / 2))
                {
                    moveSpeedComponent.direction.x = math.abs(moveSpeedComponent.direction.x);
                }
            }
        });
    }

    private float chancePerSecond(float probability, float dt)
    {
        float p = math.exp(math.log(probability) / (1 / dt));
        return 1 - p;
    }
}
