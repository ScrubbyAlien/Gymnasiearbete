using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ComponentUtils;

public class InfRadiusToggle : MonoBehaviour
{
    public GameObject radiusCirclePF;
    public Transform border;

    InfectionParameters p;

    bool radiusActive;

    float sf;

    void Start()
    {
        p = GameObject.FindObjectOfType<InfectionParameters>().GetComponent<InfectionParameters>();
        radiusActive = false;
        sf = ScalingFactor(0.12f);
    }

    void Update()
    {
        float radius = ((p.infectionRadius * border.localScale.x * 2) / p.lengthOfSide) * 2
                        / sf;

        if (p.showInfectionRadius && !radiusActive)
        {
            GameObject[] students = GameObject.FindGameObjectsWithTag("Student");
            foreach (GameObject s in students)
            {
                if (s.HasComponent<Infected>())
                {
                    Transform radiusCircle = GameObject.Instantiate(radiusCirclePF, Vector3.zero, Quaternion.identity).transform;
                    radiusCircle.localScale = new Vector3(radius, radius, 1);
                    radiusCircle.parent = s.transform;
                    radiusCircle.localPosition = new Vector3(0, 0, 1);
                    radiusActive = true;
                    break;
                }
            }
        }
        if (!p.showInfectionRadius)
        {
            Destroy(GameObject.FindGameObjectWithTag("infRadius"));
            radiusActive = false;
        }
        if (radiusActive)
        {

        }

    }

    public void ResetRadiusCircle()
    {
        radiusActive = false;
    }

    float ScalingFactor(float area)
    {
        return Mathf.Sqrt(area * 4 / Mathf.PI);
    }
}
