using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Unity.Mathematics;

public class CheckVisibility : MonoBehaviour
{
    private Vector3 pPosition;
    private Vector3 tLocation;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }else if (other.CompareTag("Boss")){
            pPosition = PlayerMovement.playerPosition;
            do //checking x value isn't too close to player
            {
                tLocation.x = pPosition.x + UnityEngine.Random.Range(-10, 10);
            } while (math.abs(tLocation.x) - 2 <= math.abs(pPosition.x) && math.abs(tLocation.x) + 1.5 >= math.abs(pPosition.x));

            do //checking z value isn't too close to player
            {
                tLocation.z = pPosition.z + UnityEngine.Random.Range(-6, 6);
            } while (math.abs(tLocation.z) - 2 <= math.abs(pPosition.z) && math.abs(tLocation.z) + 1.5 >= math.abs(pPosition.z));
            other.gameObject.transform.position = tLocation;
        }
    }
}
