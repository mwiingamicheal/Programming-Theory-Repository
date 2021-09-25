using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    public Slider healthIndicator;
    public int playerHealth;
    public int stamina;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        playerHealth = 100;
        stamina = 100;

       
    }

    // Update is called once per frame
    void Update()
    {
        healthIndicator.value = playerHealth;

        if (playerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
       
    }
}
