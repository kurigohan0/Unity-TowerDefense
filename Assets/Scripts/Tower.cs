using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : Building
{
    [SerializeField]
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
    [SerializeField]
    protected GameObject FocusPoint;
    [SerializeField]
    protected GameObject UICanvas;
    private CameraController CameraObject;
    void Start()
    {
        CameraObject = Camera.main.GetComponent<CameraController>();
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

    void OnMouseDown()
    {
        if (!CameraObject.isFocusing)
        {
            CameraObject.GoToFocusPoint(FocusPoint);  
            UICanvas.GetComponent<TowerUI>().ShowUI();
        }
    }

    public void ReturnCam()
    {
        CameraObject.ReturnToDefaultPosition();
        UICanvas.GetComponent<TowerUI>().HideUI();

    }



}
