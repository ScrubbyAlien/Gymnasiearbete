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

    InfectionParameters p;
    float borderLength;

    void Start()
    {
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();
        borderLength = GameObject.FindGameObjectWithTag("Border").
                       gameObject.GetComponent<Transform>().localScale.x * 2;
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

        //Gets a new speed and direction after a certain time period has passed.
        if (Time.time >= timeSinceLastDirChange + timeUntilNextDirChange)
        {
            dir = GetRandDir();
            timeSinceLastDirChange = Time.time;
            timeUntilNextDirChange = Random.Range(0.5f, 3f);
            mRidigbody.velocity = dir * speed;
        }
        if (Time.time >= timeSinceLastSpeedChange + timeUntilNextSpeedChange)
        {
            speed = GetRandSpeed(p.minSpeed, p.maxSpeed) * borderLength / p.lengthOfSide;
            timeSinceLastSpeedChange = Time.time;
            timeUntilNextSpeedChange = Random.Range(0.5f, 3f);
            mRidigbody.velocity = dir * speed;
        }


        //Gets a new direction and speed if the ball collides with the wall and
        //casts a ray in new direction to check if it still points towards the wall.
        //Will get a new randDir and try again if it still points to the wall.
        if (gameObject.GetComponent<CircleCollider2D>().IsTouchingLayers(borderMask))
        {
            dir = GetRandDir();
            speed = GetRandSpeed(p.minSpeed, p.maxSpeed) * borderLength / p.lengthOfSide;
            mRidigbody.velocity = dir * speed;
            bool pointingAtWall = true;
            while (pointingAtWall)
            {
                if (Physics2D.Raycast(transform.position, dir, 1f, borderMask))
                {
                    dir = GetRandDir();
                }
                else
                {
                    pointingAtWall = false;
                }
            }
        }

    }

    Vector2 GetRandDir()
    {
        float randAngle = Random.Range(0f, 2 * Mathf.PI);
        return new Vector2(Mathf.Cos(randAngle), Mathf.Sin(randAngle));
    }

    float GetRandSpeed(float min, float max)
    {
        return Random.Range(min, max);
    }
}
