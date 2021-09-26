using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent enemNavAgent;
    private Transform playerTrans;

    public float enemySpeed { get; private set; } // ENCAPSULATION
   

    private void Awake()
    {
        enemNavAgent = GetComponent<NavMeshAgent>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        enemySpeed = 1.5f;
    }
    
    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        enemNavAgent.speed = enemySpeed;
        enemNavAgent.SetDestination(playerTrans.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            DealDamage(10);
        } else if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }


    public virtual void DealDamage(int damage)
    {
        PlayerHealth.Instance.playerHealth -= damage;
    }

}
