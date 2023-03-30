using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //[HideInInspector]
    public Vector3 direction;
    [SerializeField]
    private float speed = 10;

    private Controls playerInput;

    private void Start()
    {
        StartCoroutine(nameof(WaitToDie));
    }
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    IEnumerator WaitToDie()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
