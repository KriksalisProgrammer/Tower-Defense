using UnityEngine;
using System.Collections;

public class SpawnMobs : MonoBehaviour
{
    public Transform ememyPrefab;
    public Transform spawnPoin;

    public float timeBetweenWaves = 5f;

    private float _countDown = 2f;
    private int _waveIndex = 0;
    private void Update()
    {
        if(_countDown<=0f)
        {
            StartCoroutine(SpawnWave());
            _countDown = timeBetweenWaves;
        }
        _countDown -= Time.deltaTime;
    }
    private IEnumerator SpawnWave()
    {
        for(int i=0;i<_waveIndex;i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        _waveIndex++;
    }
    private void SpawnEnemy()
    {
        Instantiate(ememyPrefab, spawnPoin.position, spawnPoin.rotation);
    }
}
