using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject gun;
    [SerializeField]
    private Vector3 constraints;
    //[SerializeField]
    public Vector3 direction;
    [SerializeField]
    private float speed = 10;
    private Controls playerInput;

    public static Vector3 playerPosition;
    public static Vector3 previousPosition;
    public Transform currentPosition;

    public float rotationSpeed;

    private void Awake()
    {
        gameObject.SetActive(true);
        gun.SetActive(true);
    }

    void Start()
    {
        playerInput = new Controls();
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    void FixedUpdate()
    {
        previousPosition = transform.position;
        direction.x = playerInput.Player.Movement.ReadValue<Vector2>().x;
        direction.y = 0;
        direction.z = playerInput.Player.Movement.ReadValue<Vector2>().y;
        transform.localPosition += direction * speed * Time.deltaTime; //Time.deltaTime controls speed at what things happen based on framerate.
        if(direction.x != 0 || direction.z != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z)), Time.deltaTime * rotationSpeed);

        }
        playerPosition = transform.position;
    }
}
