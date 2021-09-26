using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;
    private Transform rabbitTrans;
    public static float timer;
    public GameObject healthBar;
    public Text timerText;
    

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
        DisplayTime();  // ABSTRACTION
        
    }

    void SpawnHealth()
    {
        int randomEnemy = Random.Range(0, 3);

        Instantiate(healthBar, ChooseRandomPosition(), gameObject.transform.rotation);
    }

    void CreateEnemy()
    {
        int randomEnemy = Random.Range(0, 2);
        
        Instantiate(enemies[randomEnemy], ChooseRandomPosition(), gameObject.transform.rotation);
    }

     IEnumerator SpawnEnemy(int wait)
    {

        yield return new WaitForSeconds(wait);
        CreateEnemy();
        SpawnHealth();
        
        StartCoroutine(SpawnEnemy(3)); //ABSTRACTION

    }

    void TimeGame()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
    }

    Vector3 ChooseRandomPosition()
    {
        int randomZValue = Random.Range(-40, 40);
        int randomXValue = Random.Range(-30,30);

        Vector3 randomSpawnPos = new Vector3(randomXValue, 0, randomZValue);
        return randomSpawnPos;
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    } 

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void DisplayTime()
    {
        timerText.text = "Time: " + timer;
    }

   
}
