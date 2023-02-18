using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollower : AIBehaviour
{
    // public Collider2D enemyCollider;
    // public Collider2D groundCollider;
    public int damage = 1;
    public float fieldOfVisionForFollowing = 60;
    public override void PerformDetection(Boat_Controller boat, AIDetector detector)
    {
        if (TargetInFOV(boat, detector))
            boat.HandleBoatFollowTarget(detector.Target);

        boat.HandleBoatTurn(detector.Target);
    }

    // private void Start() {
    //     Physics2D.IgnoreCollision(enemyCollider, groundCollider);
    // }

    private void Update() {
        
    }

    private bool TargetInFOV(Boat_Controller boat, AIDetector detector)
    {
        var direction = detector.Target.position - boat.Rotate.transform.position;
        if (Vector2.Angle(boat.Rotate.transform.right, direction) < fieldOfVisionForFollowing / 2)
        {
            return true;
        }
        return false;
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     Debug.Log(collision.gameObject.tag);
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         Debug.Log("acertei");
    //         var damagable = collision.GetComponent<Damage>();
    //         if (damagable != null)
    //         {
    //             damagable.Hit(damage);
    //         }
    //         gameObject.SetActive(false);
    //     }
    // }

    private void OnCollisionEnter(Collision collision) 
    {
        Debug.Log(collision.gameObject.tag);
        Debug.Log("acertei");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("acertei");
            var damagable = collision.gameObject.GetComponent<Damage>();
            if (damagable != null)
            {
                damagable.Hit(damage);
            }
            gameObject.SetActive(false);
        }
    }
}
