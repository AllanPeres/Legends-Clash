using UnityEngine;
using System.Collections;
using System;

public class Health : MonoBehaviour
{

    [SerializeField] int healthPoints = 100;

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            Died();
        }
    }

    private void Died()
    {
        Destroy(gameObject);
    }
}
