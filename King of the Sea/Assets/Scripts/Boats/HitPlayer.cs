using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    //instanciando objeto
    public SpriteRenderer render;
    public Sprite[] sprite;
    public Sprite xplosion;
    private int spriteNumber = 0;

    //se player for atingido, muda o sprite baseado na vida
    public void OnHitBoatPlayer(int health)
    {
        if (health == 4)
        {
            StartCoroutine(DamageBoat());
        }
        if (health == 2)
        {
            spriteNumber++;
            StartCoroutine(DamageBoat());
        }
    }

    //se inimigo for atingido, muda o sprite baseado na vida
    public void OnHitBoatEnemy(int health)
    {
        if (health == 1)
        {
            StartCoroutine(DamageBoat());
        }
    }
    //muda para um sprite de explosao antes de mudar para o novo sprite
    private IEnumerator DamageBoat()
    {
        render.sprite = xplosion;
        Debug.Log("aoba");
        yield return new WaitForSeconds(0.3f);
        render.sprite = sprite[spriteNumber];
    }
}
