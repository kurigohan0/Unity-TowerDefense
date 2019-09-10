using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Building
{
    protected Transform CurrentTarget;
    [SerializeField]
    protected float AttackRange;
    [SerializeField]
    protected float TowerDamage;
    [SerializeField]
    protected float DelayBetweenShots;
    [SerializeField]
    protected GameObject[] enemies;
    protected List<GameObject> targetEnemies;
    protected string EnemyTag = "Enemy";
    protected bool isShoot = false;
    protected Enemy targetEnemy;
    [SerializeField]
    protected bool isStaticTower;

    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}
