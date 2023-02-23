using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Mover : MonoBehaviour
{
    //instanciando objeto
    public Rigidbody2D rbd;
    private Vector2 movementVector;
    public float maxSpeed = 20f;
    public float rotationSpeed = 5f;

    public float acceleration = 70;
    public float deacceleration = 50;
    public float currentSpeed = 0;
    public float currentForwardSpeed = 1;

    private void Awake()
    {
        rbd = GetComponentInParent<Rigidbody2D>();
    }

    // move o barco para frente e impede dele ir para tras
    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);

        if (movementVector.y > 0)
        {
            currentForwardSpeed = 1;
        }
        else if (movementVector.y < 0)
        {
            currentSpeed = 0;
            currentForwardSpeed = 0;
        }
    }

    //faz o barco acelerar de desacelerar
    private void CalculateSpeed(Vector2 movementVector)
    {
        if (Math.Abs(movementVector.y) > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deacceleration * Time.deltaTime;
        }
        currentSpeed = Math.Clamp(currentSpeed, 0, maxSpeed);
    }


    //faz o barco virar e se mover
    void FixedUpdate()
    {
        rbd.velocity = (Vector2)transform.up * currentSpeed * currentForwardSpeed * Time.fixedDeltaTime;
        rbd.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));
    }

}
