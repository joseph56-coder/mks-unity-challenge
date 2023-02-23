using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFollower : AIBehaviour
{
    //instanciando objeto
    // public Collider2D enemyCollider;
    // public Collider2D groundCollider;
    public int damage = 1;
    public float fieldOfVisionForFollowing = 60;
    public SpriteRenderer render;
    public Sprite xplosion;
    public AudioSource audioSource;

    //performa a deteccao para ver se o player esta no a frente do inimigo e para persegui-lo
    //se nao tiver ele rotaciona ate estar
    public override void PerformDetection(Boat_Controller boat, AIDetector detector)
    {
        if (TargetInFOV(boat, detector))
            boat.HandleBoatFollowTarget(detector.Target);

        boat.HandleBoatTurn(detector.Target);
    }

    // private void Start() {
    //     Physics2D.IgnoreCollision(enemyCollider, groundCollider);
    // }

    private void Update()
    {

    }

    //verifica se o player esta na frente do barco e retorna true ou false
    private bool TargetInFOV(Boat_Controller boat, AIDetector detector)
    {
        var direction = detector.Target.position - boat.Rotate.transform.position;
        if (Vector2.Angle(boat.Rotate.transform.right, direction) < fieldOfVisionForFollowing / 2)
        {
            return true;
        }
        return false;
    }

    //verifica se colidiu com o player para explodir e causar dano
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("acertei");
            var damagable = collision.transform.GetComponent<Damage>();
            if (damagable != null)
            {
                damagable.Hit(damage);
                StartCoroutine(DamageBoat());
            }
        }
    }

    //faz a animacao de explosao e depois destroi o barco
    private IEnumerator DamageBoat()
    {
        render.sprite = xplosion;
        audioSource.Play();
        yield return new WaitForSeconds(0.3f);
        Destroy(transform.parent.gameObject);
    }
}
