using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float HP;
    void Update()
    {
        if (HP <= 0)
        {
            HP = 0;
            GameObject.Find("SpawnPoint").GetComponent<WaveSpawn>().Stop();
            Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
            foreach (var enemy in enemies)
            {
                enemy.Stop();
            }
            GameObject.Find("Canvas").GetComponent<UIProcessing>().ShowGameOver();
        }

    }


    public void SetHP(float hp)
    {
        HP = hp;
    }

    public float GetHP()
    {
        return HP;
    }
}
