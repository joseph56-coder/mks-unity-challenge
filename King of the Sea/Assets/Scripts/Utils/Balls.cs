using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Balls : MonoBehaviour
{
    //instanciando objeto
    public float speed = 10;
    public int damage = 1;
    public float maxDistance = 10;

    private Vector2 startPosition;
    private float conquareDistance = 0;
    private Rigidbody2D rbd;

    public UnityEvent OnHit = new UnityEvent();
    void Awake()
    {
        rbd = GetComponent<Rigidbody2D>();

    }

    //pegar a posicao iniciar e atira a bala para frente usando a velocidade setada

    public void Initialize()
    {
        startPosition = transform.position;
        rbd.velocity = transform.up * speed;
    }

    //verifica se a distancia sem colidir em nada e maior ou igual a permitida
    //se nao for, ele e desabilitado
    void Update()
    {
        conquareDistance = Vector2.Distance(transform.position, startPosition);
        if (conquareDistance >= maxDistance)
        {
            DisableObject();
        }
    }
    //desabilita a bala
    private void DisableObject()
    {
        rbd.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    //verifica se atingiu algum barco, se nao, so desabilita
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("acertei");
        OnHit?.Invoke();
        var damagable = collision.GetComponent<Damage>();
        if (damagable != null)
        {
            damagable.Hit(damage);
        }
        DisableObject();
    }


}
