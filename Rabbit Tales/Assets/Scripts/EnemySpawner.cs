using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;
    private Transform rabbitTrans;
    public float timer;

    private void Awake()
    {
        rabbitTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Start()
    {
        StartCoroutine(SpawnEnemy(3));
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeGame();
    }


    void CreateEnemy()
    {
        int randomEnemy = Random.Range(0, 2);
        Instantiate(enemies[randomEnemy], gameObject.transform.position, gameObject.transform.rotation);
    }

     IEnumerator SpawnEnemy(int wait)
    {

        yield return new WaitForSeconds(wait);
        CreateEnemy();
        
        StartCoroutine(SpawnEnemy(3));

    }

    void TimeGame()
    {
        timer += Time.deltaTime;

        

        Debug.Log(timer);
    }
}
