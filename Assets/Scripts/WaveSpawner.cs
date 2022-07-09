using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    
    public Transform EnemiesSpawnPoint;
    public Transform enemyPrefab;

    public float timeBetweenWaves = 5.5f;
    private float countDown = 2f;

    private int waveNumber = 1;

    public TextMeshProUGUI waveCountdownText;

    private void Start()
    {
        EnemiesSpawnPoint = transform.GetChild(0);
    }

    private void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }

        countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
        
        waveCountdownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
        waveNumber++;
        PlayerStats.instance.Rounds++;
    }   
    

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab.gameObject, EnemiesSpawnPoint.position, EnemiesSpawnPoint.rotation);
        enemy.transform.SetParent(EnemiesSpawnPoint);
    }
}