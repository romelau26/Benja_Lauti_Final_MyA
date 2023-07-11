using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicStats : MonoBehaviour
{
    public float _movementSpeed;
    public int MaxHealth;
    public int CurrentHealth;
    public virtual void ReciveDamage(int damage)
    {
        CurrentHealth -= damage;
    }
}
