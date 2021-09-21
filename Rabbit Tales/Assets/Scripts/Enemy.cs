using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent enemNavAgent;
    public Transform playerTrans;

    public int enemySpeed;
    public int damage = 20;

    private void Awake()
    {
        enemNavAgent = GetComponent<NavMeshAgent>();
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
        }
    }
}
