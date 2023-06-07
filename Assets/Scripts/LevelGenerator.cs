using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;

    public int numberOfPlatforms = 200;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    public Transform[] CoinPrefabs;
    public int coinPrabability;
    public Vector3 coinOffset;
    public GameObject WinFlag;

    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            GameObject platformPref = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            if (i + 1 == numberOfPlatforms)
            {
                Vector3 newPos = platformPref.transform.position + coinOffset;
                Instantiate(WinFlag, newPos, Quaternion.identity, platformPref.transform);
                return;
            }
            else if ((i + 1) % coinPrabability == 0)
            {
                int coinIndex = Random.Range(0, CoinPrefabs.Length);
                Debug.Log("Coin 🌟");
                Vector3 newPos = platformPref.transform.position + coinOffset;
                Instantiate(CoinPrefabs[coinIndex], newPos, Quaternion.identity, platformPref.transform);
            }

        }
    }
}
