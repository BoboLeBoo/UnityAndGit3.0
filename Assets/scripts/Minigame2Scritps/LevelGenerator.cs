using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject asteroidBigPrefab;
    [SerializeField] private GameObject asteroidMiddlePrefab;
    [SerializeField] private GameObject asteroidSmallPrefab;
    [SerializeField] private GameObject teleborderL;
    [SerializeField] private GameObject teleborderR;

    private float platformInterval = 0.2f;
    private Vector2 screenBounds;

    private void Start()
    {
        StartCoroutine(spawnAsteroidWaves());
    }

    private void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    private void spawnAsteroids()
    {
        GameObject asteroid = Instantiate(asteroidSmallPrefab) as GameObject;
        asteroid.transform.position = new Vector2(Random.Range(teleborderL.transform.position.x, teleborderR.transform.position.x), screenBounds.y + Random.Range(-8f,20f));
    }

    private IEnumerator spawnAsteroidWaves()
    {
        while(true) 
        {
            yield return new WaitForSeconds(platformInterval);
            spawnAsteroids();
        }
        //GameObject newPlatform = Instantiate(platform, new Vector3(this.transform.position.x + Random.Range(-5f,5),this.transform.position.y + Random.Range(-6f,6f),0),Quaternion.identity);
        //StartCoroutine(spawnPlatform(interval, newPlatform));
    }
}
