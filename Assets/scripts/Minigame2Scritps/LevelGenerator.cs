using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platformLongPrefab;
    [SerializeField] private GameObject platformMiddlePrefab;
    [SerializeField] private GameObject platformShortPrefab;
    //[SerializeField] private Rigidbody2D Player;

    private float platformInterval = 3.5f;

    private void Start()
    {
        StartCoroutine(spawnPlatform(platformInterval, platformShortPrefab));
        StartCoroutine(spawnPlatform(platformInterval, platformMiddlePrefab));
        StartCoroutine(spawnPlatform(platformInterval, platformLongPrefab));
    }

    private IEnumerator spawnPlatform(float interval, GameObject platform)
    {
        yield return new WaitForSeconds(interval);
        GameObject newPlatform = Instantiate(platform, new Vector3(Random.Range(-5f,5), Random.Range(-6f,6f),0),Quaternion.identity);
        StartCoroutine(spawnPlatform(interval, newPlatform));
    }

}
