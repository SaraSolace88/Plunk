using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 direction;
    private Vector3 playerPosition;
    public static Vector3 previousPosition;

    [SerializeField]
    private float speed;
    void Start()
    {

    }

    void FixedUpdate()
    {
        previousPosition = gameObject.transform.position;
        playerPosition = PlayerMovement.playerPosition;
        if (playerPosition.x < transform.position.x)
        {
            direction.x = -1;
        }
        else if(playerPosition.x > transform.position.x)
        {
            direction.x = 1;
        }
        else
        {
            direction.x = 0;
        }

        if (playerPosition.z < transform.position.z)
        {
            direction.z = -1;
        }
        else if(playerPosition.z > transform.position.z)
        {
            direction.z = 1;
        }
        else
        {
            direction.z = 0;
        }
        transform.localPosition += direction * speed * Time.deltaTime;
    }
}
