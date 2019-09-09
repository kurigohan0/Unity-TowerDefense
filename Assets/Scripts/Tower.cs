using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected Transform CurrentTarget;
    [SerializeField]
    protected float AttackRange;
    [SerializeField]
    protected float TowerDamage;
    [SerializeField]
    protected float TowerTurnSpeed;
    [SerializeField]
    protected float DelayBetweenShots;
    [SerializeField]
    protected string EnemyTag = "Enemy";
    protected bool isShoot = false;
    protected Enemy targetEnemy;

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTarget == null)
            return;

        if (!isShoot)
        {
            StartCoroutine(Shoot());
        }

        LockToNewTarget();
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
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
        Vector3 dir = CurrentTarget.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * TowerTurnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    IEnumerator Shoot()
    {   
        if (CurrentTarget != null)
        {
            isShoot = true;
            CurrentTarget.GetComponent<Enemy>().SetDamage(TowerDamage);
            yield return new WaitForSeconds(DelayBetweenShots);
            isShoot = false;
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}
