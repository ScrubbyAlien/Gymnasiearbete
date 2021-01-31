using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialDistancer : MonoBehaviour
{
    public float strength;

    public LayerMask layerMask;

    public float timeBetweenChecks;
    float startTime;

    Rigidbody2D mRigidBody;

    InfectionParameters p;

    void Start()
    {
        mRigidBody = GetComponent<Rigidbody2D>();
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();
        startTime = Time.unscaledTime;
    }

    void Update()
    {
        float radius = ((p.infectionRadius * p.border.localScale.x * 2) * 2 / p.lengthOfSide);
        if (Time.unscaledTime >= startTime + timeBetweenChecks)
        {
            for (int i = 0; i < 10; i++)
            {
                RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, RadToVec2(2 * Mathf.PI * i / 10), radius, layerMask);
                if (hitInfo)
                {
                    Vector2 difference = hitInfo.transform.position - transform.position;
                    mRigidBody.AddForce(RadToVec2(2 * Mathf.PI * i / 10) * strength / Mathf.Max(difference.magnitude, 0.5f));
                }
            }
            startTime = Time.unscaledTime;
        }
    }

    public static Vector2 RadToVec2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
}
