using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platformLongPrefab;
    [SerializeField] private GameObject platformMiddlePrefab;
    [SerializeField] private GameObject platformShortPrefab;

    private float platformInterval = 1.5f;
    private Vector2 screenBounds;

    private void Start()
    {
        //StartCoroutine(spawnPlatform(platformInterval, platformShortPrefab));
        StartCoroutine(spawnPlatform(platformInterval, platformMiddlePrefab));
        //StartCoroutine(spawnPlatform(platformInterval, platformLongPrefab));
    }

    private void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    private IEnumerator spawnPlatform(float interval, GameObject platform)
    {
        yield return new WaitForSeconds(interval);
        GameObject newPlatform = Instantiate(platform, new Vector3(this.transform.position.x + Random.Range(-5f,5),this.transform.position.y + Random.Range(-6f,6f),0),Quaternion.identity);
        StartCoroutine(spawnPlatform(interval, newPlatform));
    }

}
