using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent enemNavAgent;
    private Transform playerTrans;

    public float enemySpeed;
    public int damage = 10;

    private void Awake()
    {
        enemNavAgent = GetComponent<NavMeshAgent>();
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
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
            PlayerHealth.Instance.playerHealth -= damage;
        } else if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }

}
