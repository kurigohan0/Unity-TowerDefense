using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
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
    protected Stats stats;
    public TowerUpgrade[] UpgradeArray = new TowerUpgrade[5];

    private CameraController CameraObject;
    void Start()
    {
        CameraObject = Camera.main.GetComponent<CameraController>();
        Level = 1;
        stats = GameObject.Find("EventSystem").GetComponent<Stats>();
        for (int i = 1; i < UpgradeArray.Length; i++)
        {
            UpgradeArray[i] = new TowerUpgrade
            {
                Damage = (i * 10) + 45,
                Cost = i * 20
            };
            Debug.Log(UpgradeArray[i].Damage + " | " + UpgradeArray[i].Cost);
        }
        



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
        if ((stats.GetMoney() >= UpgradeArray[Level].Cost) && Level < UpgradeArray.Length)
        {
            stats.AddMoney(-UpgradeArray[Level].Cost);
            TowerDamage = UpgradeArray[Level].Damage;
            Level++;
        }

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
