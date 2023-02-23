using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damage : MonoBehaviour
{
    //instanciando objeto
    public int MaxHealth = 3;
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
    public UnityEvent<int> OnHit;

    void Start()
    {
        Health = MaxHealth;
    }

    //checa a vida do barco e se deve destruir ele ou continuar vivo
    internal void Hit(int damagePoints)
    {
        Health -= damagePoints;

        if (health <= 0)
        {
            OnDead?.Invoke();
        }
        else
        {
            OnHit?.Invoke(Health);
        }
    }
}
