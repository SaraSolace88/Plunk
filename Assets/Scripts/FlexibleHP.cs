using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexibleHP : MonoBehaviour
{
    [SerializeField]
    private int flexhealth = 5;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out HealthSystem healthSystem))
        {
            healthSystem.UpdateHealth(flexhealth);
        } 
    }
}
