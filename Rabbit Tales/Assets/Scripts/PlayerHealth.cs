using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int playerHealth;
 
    void Start()
    {
        playerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
       
    }
}
