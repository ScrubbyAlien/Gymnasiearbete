using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infector : MonoBehaviour
{
    public int numberToInfect;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Infect(numberToInfect);
        }
    }

    void Infect(int n)
    {
        GameObject[] students = GameObject.FindGameObjectsWithTag("Student");

        for (int i = 0; i < numberToInfect; i++)
        {
            if (students[i].HasComponent<Infected>() == false)
            {
                students[i].AddComponent<Infected>();
            }
        }
    }
}

public static class hasComponent
{
    public static bool HasComponent<T>(this GameObject flag) where T : Component
    {
        return flag.GetComponent<T>() != null;
    }
}
