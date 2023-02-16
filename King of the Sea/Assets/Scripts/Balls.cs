using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public float speed = 10;
    public int damage = 1;
    public float maxDistance = 10;

    private Vector2 startPosition;
    private float conquareDistance = 0;
    private Rigidbody2D rbd;

    void Awake()
    {
        rbd = GetComponent<Rigidbody2D>();

    }

    public void Initialize()
    {
        startPosition = transform.position;
        rbd.velocity = transform.up * speed;
    }

    void Update()
    {
        conquareDistance = Vector2.Distance(transform.position, startPosition);
        if (conquareDistance >= maxDistance)
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rbd.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("acertei");
        var damagable = collision.GetComponent<Damage>();
        if (damagable != null)
        {
            damagable.Hit(damage);
        }
        DisableObject();
    }


}
