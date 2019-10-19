using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform EnemyPrefab;
    private float countdown = 2f;
    [SerializeField] private Transform SpawnPosition;
    private int waveNumber = 0;
    [SerializeField]
    private float TimeBetweenWaves = 5f;

    private bool stop = false;

    void Start()
    {
        SpawnPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            if (countdown <= 0f)
            {
                StartCoroutine("CreateWawe");
                countdown = TimeBetweenWaves;
            }

            countdown -= Time.deltaTime;
        }
    }

    public void Stop()
    {
        stop = true;
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
        Instantiate(EnemyPrefab, SpawnPosition.position, SpawnPosition.rotation);
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
