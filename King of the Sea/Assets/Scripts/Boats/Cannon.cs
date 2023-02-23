using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class Cannon : MonoBehaviour
{
    //instanciando objeto
    // public List<Transform> cannons;
    public GameObject ballPrefabs;
    public float reloadDelay = 3;

    private bool canShoot = true;
    private Collider2D[] boatCollider;
    private float currentDelay = 0;

    private ObjectPool ballsPool;
    [SerializeField]
    private int ballsPoolCount = 10;

    void Awake()
    {
        boatCollider = GetComponentsInParent<Collider2D>();
        ballsPool = GetComponent<ObjectPool>();
    }

    //inicializa o script para limitar o numero de balas
    private void Start()
    {
        ballsPool.Initialize(ballPrefabs, ballsPoolCount);
    }

    void Update()
    {
        //verifica se pode atirar, senao, tera que esperar  delay para atirar denvo
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }
    // faz o barco atirar e nao atingir seu collider
    public void shoot(List<Transform> cannons)
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadDelay;

            foreach (var cannon in cannons)
            {
                //GameObject balls = Instantiate(ballPrefabs);
                GameObject balls = ballsPool.CreateObject();
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
