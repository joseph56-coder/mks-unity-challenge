using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Controller : MonoBehaviour
{
    public Cannon Cannon;
    public Boat_Mover Boat_Mover;
    public RotateBoatEnemy Rotate;
    public Follow follow;


    public List<Transform> Front_cannons, Edge_Left_cannons;

    void Awake()
    {
        if (Boat_Mover == null)
        {
            Boat_Mover = GetComponentInChildren<Boat_Mover>();
        }
        if (Rotate == null)
        {
            Rotate = GetComponentInChildren<RotateBoatEnemy>();
        }
        if (follow == null)
        {
            follow = GetComponentInChildren<Follow>();
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

    public void HandleBoatTurn(Transform pointerPosition)
    {
        Rotate.Rotate(pointerPosition);
    }

    public void HandleBoatFollowTarget(Transform pointerPosition)
    {
        follow.FollowTarget(pointerPosition);
    }


}
