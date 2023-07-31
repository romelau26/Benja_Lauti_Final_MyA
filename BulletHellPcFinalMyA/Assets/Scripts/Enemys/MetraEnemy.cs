using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetraEnemy : BasicStats
{
    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }
    private void Update()
    {
        transform.position += (new Vector3(0, 0, -1) * _movementSpeed) * Time.deltaTime;
    }
}
