using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerSphere : Enemy

    // INHERITANCE
{

    private void Awake()
    {
        
    }

    public override void DealDamage(int damage)
    {

        damage = 20;
        PlayerHealth.Instance.playerHealth -= damage;  // POLYMORPHISM
    }
}
