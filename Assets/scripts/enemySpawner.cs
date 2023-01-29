using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class enemySpawner : MonoBehaviour
{
    private int score = 0;

    [SerializeField]
    
    private GameObject enemy; 
    private int counter;
    private float timedelay = 8f;

    [SerializeField]
    private float spawnerIntervall = 3.5f;
    void Start()
    {
        InvokeRepeating("spawner", 2.0f, 10f);
       
    }

    private void spawner()
    {
        
         StartCoroutine(spawnEnemy(spawnerIntervall, enemy));

    	
    }

    // Update is called once per frame

    private IEnumerator spawnEnemy(float intervall, GameObject enemy)
    {
        yield return new WaitForSeconds(intervall);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-1.8f,1.8f), Random.Range(3f,4f),0),Quaternion.identity);
        StartCoroutine(spawnEnemy(intervall,enemy));
        score = scoreManager.instance.getScore();
        Debug.Log("spawnIntervall" + spawnerIntervall);
        if (score >= 3)
        {
            spawnerIntervall = 2f;
        }
        Destroy(newEnemy,timedelay);
    }




}
