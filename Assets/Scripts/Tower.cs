using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Start is called before the first frame update

    protected Transform target;
    [SerializeField]
    protected float range;
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float turnSpeed = 10f;
    [SerializeField]
    protected float delay;
    [SerializeField]
    protected string enemyTag = "Enemy";
    protected Transform partToRotate;
    protected bool isShoot = false;
    protected Enemy targetEnemy;



    void Start()
    {
        partToRotate = transform;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        if (!isShoot)
        {
            StartCoroutine(Shoot());
        }

        LockOnTarget();

    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
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

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    IEnumerator Shoot()
    {   
        if (target != null)
        {
            isShoot = true;
            target.GetComponent<Enemy>().SetDamage(damage);
            TowerSound.Play();
            yield return new WaitForSeconds(delay);
            isShoot = false;
        }
    }
}
