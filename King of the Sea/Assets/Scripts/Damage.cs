using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{
    public int MaxHealth = 3;
    public SpriteRenderer render;
    public Sprite[] sprite;
    public Sprite xplosion;
    [SerializeField]
    private int health;



    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }

    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit;

    void Start()
    {
        Health = MaxHealth;
    }

    internal void Hit(int damagePoints)
    {
        Health -= damagePoints;
        if (health == 2)
        {
            StartCoroutine(DamageBoat());
        }
        if (health <= 0)
        {
            OnDead?.Invoke();
        }
        else
        {
            OnHit?.Invoke();
        }
    }

    private IEnumerator DamageBoat()
    {
        render.sprite = xplosion;
        Debug.Log("aoba");
        yield return new WaitForEndOfFrame();
        render.sprite = sprite[0];
    }
    
}
