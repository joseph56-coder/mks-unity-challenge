using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    // public List<Transform> cannons;
    public GameObject ballPrefabs;
    public float reloadDelay = 3;

    private bool canShoot = true;
    private Collider2D[] boatCollider;
    private float currentDelay = 0;

    void Awake()
    {
        boatCollider = GetComponentsInParent<Collider2D>();
    }

    void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }
    public void shoot(List<Transform> cannons)
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;

            foreach (var cannon in cannons)
            {
                GameObject balls = Instantiate(ballPrefabs);
                balls.transform.position = cannon.position;
                balls.transform.localRotation = cannon.rotation;
                balls.GetComponent<Balls>().Initialize();
                foreach (var collider in boatCollider)
                {
                    Physics2D.IgnoreCollision(balls.GetComponent<Collider2D>(), collider);
                }
            }

        }
    }
}
