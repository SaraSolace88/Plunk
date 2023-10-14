using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInPlace : MonoBehaviour
{
    private Vector3 position;
    private void Start()
    {
        position = gameObject.transform.position;
    }

    private void Update()
    {
        if(position != gameObject.transform.position)
        {
            gameObject.transform.position = position;
        }
    }
}
