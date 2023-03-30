using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private float fireRate = 0.1f;

    private Controls pInput;
    private bool bFireOn;

    private Vector3 playerDirection;

    private void Start()
    {
        playerDirection = new Vector3(0, 0, 1);
        StartCoroutine(nameof(PerpetualFiring));
    }

    private void Update()
    {
        if(GetComponent<PlayerMovement>().direction != Vector3.zero)
        {
            playerDirection = GetComponent<PlayerMovement>().direction;
        }
        if(!bFireOn)
        {
            StartCoroutine(nameof(PerpetualFiring));
        }
    }
    private void FireShot()
    {
        GameObject g = Instantiate(projectile, transform.position, Quaternion.identity);
        g.GetComponent<Projectile>().direction = playerDirection;
    }
    IEnumerator PerpetualFiring()
    {
        bFireOn = true;
        yield return new WaitForSeconds(fireRate);
        FireShot();
        bFireOn = false;
    }
}
