using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, описывающий финальную точку
/// </summary>
public class FinalPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float HP;
    void Update()
    {
        if (HP <= 0) //Если здоровье финальной точки меньше или равно нулю то проигрыш
        {
            HP = 0;
            GameObject.Find("SpawnPoint").GetComponent<WaveSpawn>().Stop();
            Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
            foreach (var enemy in enemies) //Останавливает всех врагов при проигрыше
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
