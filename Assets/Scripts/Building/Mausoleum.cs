using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mausoleum : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;

    private void Start() 
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(7f);
            Vector3 position = _spawnPoint.position + new Vector3(Random.Range(1.5f, -1.5f), 0f, Random.Range(1.5f, -1.5f));
            Instantiate(_enemyPrefab, position, Quaternion.identity);
        }
    }
}
