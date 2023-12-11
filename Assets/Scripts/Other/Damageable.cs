using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [Header("Damageable References")]
    public float currentHealth;
    public float maxHealth = 100f;

    public abstract void TakeDamage(float _damage);
    public abstract void Die();

    private void Start()
    {
        currentHealth = maxHealth;
    }
}

public abstract class DamageableSO : Damageable
{
    public abstract override void TakeDamage(float _damage);
    public abstract override void Die();
}