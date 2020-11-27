using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentMovement : MonoBehaviour
{
    Rigidbody2D mRidigbody;
    Camera mCamera;
    Vector3 cameraPostion;

    public LayerMask borderMask;
    float borderWidth;
    float borderHeight;
    Vector2 cameraOffset;

    Vector2 dir;
    float speed;
    float timeUntilNextDirChange;
    float timeUntilNextSpeedChange;
    float timeSinceLastDirChange;
    float timeSinceLastSpeedChange;
    Vector2 translation;

    void Start()
    {
        mRidigbody = GetComponent<Rigidbody2D>();
        mCamera = Camera.main;
        cameraPostion = mCamera.transform.position;

        borderWidth = mCamera.orthographicSize * mCamera.aspect * 2;
        borderHeight = mCamera.orthographicSize * 2;
        cameraOffset = new Vector2(cameraPostion.x, cameraPostion.y);

        timeUntilNextDirChange = 0;
        timeUntilNextSpeedChange = 0;

        timeSinceLastDirChange = 0;
        timeSinceLastSpeedChange = 0;

    }

    void Update()
    {
        if (Time.time >= timeSinceLastDirChange + timeUntilNextDirChange)
        {
            dir = GetRandDir();
            timeSinceLastDirChange = Time.time;
            timeUntilNextDirChange = Random.Range(0.5f, 3f);
            mRidigbody.velocity = dir * speed;
        }
        if (Time.time >= timeSinceLastSpeedChange + timeUntilNextSpeedChange)
        {
            speed = GetRandSpeed();
            timeSinceLastSpeedChange = Time.time;
            timeUntilNextSpeedChange = Random.Range(0.5f, 3f);
            mRidigbody.velocity = dir * speed;
        }

        if (gameObject.GetComponent<CircleCollider2D>().IsTouchingLayers(borderMask))
        {
            dir = GetRandDir();
            speed = GetRandSpeed();
            mRidigbody.velocity = dir * speed;
        }

    }


    Vector2 GetRandDir()
    {
        float randAngle = Random.Range(0f, 2 * Mathf.PI);
        Vector2 d = new Vector2(Mathf.Cos(randAngle), Mathf.Sin(randAngle));
        return d;
    }

    float GetRandSpeed()
    {
        return Random.Range(1f, 4f);
    }
}
