using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAOE : Tower
{
    Quaternion DefaultPos;
    // Start is called before the first frame update
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            // Filter by using specific layers for this object and "others" instead of using tags
            targetEnemies.Add(enemy.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            // Filter by using specific layers for this object and "others" instead of using tags
            targetEnemies.Remove(enemy.gameObject);
        }
    }

}
