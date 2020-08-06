using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            Instantiate(enemyPrefab, new Vector3(25f, UnityEngine.Random.Range(-7.5f, 10f), 0f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(1f, 2f));
        }
    }
}
