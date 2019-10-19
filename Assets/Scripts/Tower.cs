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
    protected int Level;
    private CameraController CameraObject;
    void Start()
    {
        CameraObject = Camera.main.GetComponent<CameraController>();
        Level = 1;
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
        FocusTower();   
    }

    public void FocusTower()
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

    public void DestroyTower()
    {
        ReturnCam();
        Destroy(BuildingObject, 0f);
    }

    public void SellTower()
    {
        Sell();
    }

    public void StatsTower()
    {
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIProcessing>().ShowStatsTower(this);
    }

    public void UpgradeTower()
    {

    }

    public int GetLevel()
    {
        return Level;
    }

    public float GetDamage()
    {
        return TowerDamage;
    }

    public void InfoTower()
    {
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIProcessing>().ShowInfoTower(this);
    }
}
