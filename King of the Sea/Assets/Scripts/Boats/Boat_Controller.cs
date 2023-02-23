using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Controller : MonoBehaviour
{
    //instanciando objeto
    public Cannon Cannon;
    public Boat_Mover Boat_Mover;
    public RotateBoatEnemy Rotate;
    public Follow follow;


    public List<Transform> Front_cannons, Edge_Left_cannons, Edge_Right_cannons;

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

    // faz o barco atirar para frente
    public void FrontShooter()
    {
        Cannon.shoot(Front_cannons);
    }

    // faz o barco atirar para a esquerda
    public void EdgeLeftShooter()
    {
        Cannon.shoot(Edge_Left_cannons);
    }

    //faz o barco atirar para a direita
    public void EdgeRightShooter()
    {
        Cannon.shoot(Edge_Right_cannons);
    }

    //cuida de movimentar o barco
    public void HandleMoveBody(Vector2 movementVector)
    {
        Boat_Mover.Move(movementVector);

    }

    //faz o barco inimigo rotacionar
    public void HandleBoatTurn(Transform pointerPosition)
    {
        Rotate.Rotate(pointerPosition);
    }

    //faz o barco inimigo seguir o player
    public void HandleBoatFollowTarget(Transform pointerPosition)
    {
        follow.FollowTarget(pointerPosition);
    }


}
