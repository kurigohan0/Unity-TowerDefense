using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCommon : Tower
{
    [SerializeField]
    protected float TowerTurnSpeed;
    // Start is called before the first frame update
    void Awake()
    {
        targetEnemies = new List<GameObject>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {


        if (!isShoot)
        {
            StartCoroutine(Shoot());
        }
        if (!isStaticTower)
            LockToNewTarget();
        if (CurrentTarget == null)
            return;

    }
    void UpdateTarget()
    {
        enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= AttackRange)
        {
            CurrentTarget = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            CurrentTarget = null;
        }
    }
    void LockToNewTarget()
    {
        try
        {
            Vector3 dir = CurrentTarget.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * TowerTurnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
        catch
        {

        }
    }

    new public IEnumerator Shoot()
    {
        if (CurrentTarget != null)
        {
            isShoot = true;
            CurrentTarget.GetComponent<Enemy>().SetDamage(TowerDamage);
            yield return new WaitForSeconds(DelayBetweenShots);
            isShoot = false;
        }
    }


}
