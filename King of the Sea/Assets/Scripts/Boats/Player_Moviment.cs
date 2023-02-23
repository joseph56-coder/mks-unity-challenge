using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player_Moviment : MonoBehaviour
{
    //instanciando objeto
    public UnityEvent OnFrontShooter = new UnityEvent();
    public UnityEvent OnLeftShooter = new UnityEvent();
    public UnityEvent OnRightShooter = new UnityEvent();
    public UnityEvent<Vector2> OnMovement = new UnityEvent<Vector2>();

    // Update is called once per frame
    void Update()
    {
        GetBodyMovement();
        GetShootingInput();
    }

    //verifica se o player apertou algumas das teclas para atirar
    private void GetShootingInput()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OnFrontShooter?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            OnLeftShooter?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            OnRightShooter?.Invoke();
        }
    }

    //verifica se  player apertou a tecla para se mover
    private void GetBodyMovement()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnMovement?.Invoke(movementVector.normalized);
    }

}
