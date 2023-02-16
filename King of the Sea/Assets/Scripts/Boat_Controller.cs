using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Controller : MonoBehaviour
{
    public Cannon Cannon;
    public Boat_Mover Boat_Mover;

    public List<Transform> Front_cannons, Edge_Left_cannons;

    void Awake()
    {
        if (Boat_Mover == null)
        {
            Boat_Mover = GetComponentInChildren<Boat_Mover>();
        }
    }
    public void FrontShooter()
    {
        Cannon.shoot(Front_cannons);
    }

    public void EdgeLeftShooter()
    {
        Cannon.shoot(Edge_Left_cannons);
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        Boat_Mover.Move(movementVector);

    }


}
