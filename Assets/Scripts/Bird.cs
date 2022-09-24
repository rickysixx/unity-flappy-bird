using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Vector3 currentDirection;

    [SerializeField]
    private float gravity = -9.8f;

    [SerializeField]
    private float jumpForce = 5f;

    private void OnEnable()
    {
        ResetPosition();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            currentDirection = Vector3.up * jumpForce;
        }

        currentDirection.y += gravity * Time.deltaTime;
        transform.position += currentDirection * Time.deltaTime;
    }

    public void ResetPosition()
    {
        currentDirection = Vector3.zero;
        transform.position = currentDirection;
    }
}
