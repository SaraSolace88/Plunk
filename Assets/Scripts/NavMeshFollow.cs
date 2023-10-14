using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshFollow : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent nma;
    private Vector3 playerPosition;
    private void Update()
    {
        playerPosition = PlayerMovement.playerPosition;
        nma.SetDestination(playerPosition);
    }
}
