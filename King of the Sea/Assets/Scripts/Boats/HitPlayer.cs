using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public SpriteRenderer render;
    public Sprite[] sprite;
    public Sprite xplosion;
    private int spriteNumber = 0;

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

    public void OnHitBoatEnemy(int health)
    {
        if (health == 1)
        {
            StartCoroutine(DamageBoat());
        }
    }
    private IEnumerator DamageBoat()
    {
        render.sprite = xplosion;
        Debug.Log("aoba");
        yield return new WaitForSeconds(0.3f);
        render.sprite = sprite[spriteNumber];
    }
}
