using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, описывающий башню с радиусом урона
/// </summary>
public class TowerAOE : Tower
{
    Quaternion DefaultPos;
    void Awake()
    {
        targetEnemies = new List<GameObject>();
        GetComponent<SphereCollider>().radius = AttackRange/10;
        DefaultPos = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = DefaultPos;
        if (!isShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    /// <summary>
    /// Выстрел башни
    /// </summary>
    /// <returns></returns>
    new IEnumerator Shoot()
    {
        isShoot = true;
        foreach (var tar in targetEnemies)
        {

            if (tar != null)
            {
                tar.GetComponent<Enemy>().SetDamage(TowerDamage);
            }
        }
        yield return new WaitForSeconds(DelayBetweenShots);
        isShoot = false;
    }

    /// <summary>
    /// При попадании врага в радиус башни
    /// </summary>
    /// <param name="other">Коллайдер врага</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            targetEnemies.Add(enemy.gameObject);
        }
    }

    /// <summary>
    /// При выходе врага из радиуса башни
    /// </summary>
    /// <param name="other">Коллайдер врага</param>
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            targetEnemies.Remove(enemy.gameObject);
        }
    }

}
