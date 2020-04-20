using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float Health;


    public void TakeDamage(float amount)
    {
        Health -= amount;
        Debug.Log(Health);
        if (Health <= 0f)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
