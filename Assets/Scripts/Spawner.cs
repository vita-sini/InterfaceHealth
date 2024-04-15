using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        var waitForSeconds = new WaitForSeconds(_timeBetweenSpawn);

        while (enabled)
        {
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

            Coin coin = Instantiate(_coin, _spawnPoints[spawnPointNumber].transform.position, Quaternion.identity);

            yield return waitForSeconds;
        }
    }
}
