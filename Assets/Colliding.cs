using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Colliding : MonoBehaviour
{
    public Vector3 previousPosition;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            previousPosition = PlayerMovement.previousPosition;
            Debug.Log("enter");
            other.transform.position = previousPosition;
        }else if (other.CompareTag("Enemy"))
        {
            previousPosition = EnemyMovement.previousPosition;
            other.transform.position = previousPosition;
        }
    }
}
