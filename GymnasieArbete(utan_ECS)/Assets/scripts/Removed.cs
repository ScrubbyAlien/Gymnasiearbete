using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Removed : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.grey;
    }
}
