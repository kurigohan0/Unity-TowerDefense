using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, описывающий логику спавнера волн
/// </summary>
public class WaveSpawn : MonoBehaviour
{
    [SerializeField] private Transform EnemyPrefab;
    private float countdown = 2f;
    [SerializeField] private Transform SpawnPosition;
    private int waveNumber = 0;
    [SerializeField]
    private float TimeBetweenWaves = 5f;
    [SerializeField]
    private int MaxWaves;
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

        if (waveNumber == MaxWaves)
        {
            Stop();
            StopCoroutine("CreateWawe");
            Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
            if (enemies.Length == 0)
            {
                GameObject.Find("Canvas").GetComponent<UIProcessing>().ShowLevelComplete();
            }
        }
    }

    public void Stop()
    {
        stop = true;
    }

    /// <summary>
    /// Создание волны
    /// </summary>
    /// <returns></returns>
    IEnumerator CreateWawe()
    {
        waveNumber++;

        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    /// <summary>
    /// Создание врага
    /// </summary>
    private void SpawnEnemy()
    {
        Instantiate(EnemyPrefab, SpawnPosition.position, SpawnPosition.rotation);
    }

    /// <summary>
    /// Возвращает номер волны
    /// </summary>
    /// <returns>Номер волны</returns>
    public int GetWave()
    {
        return waveNumber;
    }

    public void SetWave(int wave)
    {
        waveNumber = wave;
    }
}
