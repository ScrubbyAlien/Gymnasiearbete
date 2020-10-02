using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class testing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MakeEntity();
    }

    private void MakeEntity()
    {
        EntityManager entityManager = World.Active.EntityManager;

    }
}
