using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class MoverSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref MoveSpeedComponent moveSpeedComponent) =>
        {
            translation.Value.y += moveSpeedComponent.speed * Time.DeltaTime;

            if (translation.Value.y > 4.5f)
            {
                moveSpeedComponent.speed = -math.abs(moveSpeedComponent.speed);
            }

            if (translation.Value.y < -4.5f)
            {
                moveSpeedComponent.speed = math.abs(moveSpeedComponent.speed);
            }

        });
    }
}
