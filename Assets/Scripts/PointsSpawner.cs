using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsSpawner : MonoBehaviour
{
    public GameObject pointsPrefab;

    private void Start()
    {
        StartCoroutine(SpawnPoints());
    }

    private void Update()
    {

    }

    IEnumerator SpawnPoints()
    {
        while (true)
        {
            Instantiate(pointsPrefab, new Vector3(25f, UnityEngine.Random.Range(-7.5f, 10f), 0f), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(0f, 1f));
        }
    }
}
