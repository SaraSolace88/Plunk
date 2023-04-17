using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StandInPlaceFlexibleHP : MonoBehaviour
{
    [SerializeField]
    private int flexhealth = 5;
    private bool doNotDamage = false;

    private void OnTriggerEnter(Collider other)
    {
        doNotDamage = false;
    }
    private void OnTriggerExit(Collider other)
    {
        doNotDamage = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out HealthSystem healthSystem))
            {
                if (!doNotDamage)
                {
                    healthSystem.UpdateHealth(flexhealth);
                    StartCoroutine(nameof(Damaging));
                }
            }
        }
    }

    IEnumerator Damaging()
    {
        doNotDamage = true;
        yield return new WaitForSeconds(1);
        doNotDamage = false;
    }
}
