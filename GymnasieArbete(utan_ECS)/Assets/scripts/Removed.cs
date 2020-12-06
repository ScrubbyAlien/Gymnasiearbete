using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Removed : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
    }
}
