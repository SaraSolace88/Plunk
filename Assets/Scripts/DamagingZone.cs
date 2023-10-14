using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingZone : MonoBehaviour
{
    [SerializeField]
    private GameObject boss;

    private Vector3 position;
    private void Update()
    {
        position = boss.transform.position;
        position.x += -100;
        position.y = -.3f;
        gameObject.transform.position = position;
    }
}
