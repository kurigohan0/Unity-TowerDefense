using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform enemyPrefab;
    private float countdown = 2f;
    [SerializeField] private Transform spawnPosition;

    private int waveNumber = 0;

    public float TimeBetweenWaves = 5f;

    void Start()
    {
        spawnPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine("CreateWawe");
            countdown = TimeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }

    IEnumerator CreateWawe()
    {
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
    }

    public int GetWave()
    {
        return waveNumber;
    }

    public void SetWave(int wave)
    {
        waveNumber = wave;
    }
}
