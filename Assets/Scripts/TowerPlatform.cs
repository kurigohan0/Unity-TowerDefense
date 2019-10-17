using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatform : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] TowerSet = new GameObject[2];
    private bool alreadyPlaced = false;
    private Canvas mainCanvas;
    private Stats stats;
    [SerializeField]
    public GameObject CurrentTower;

    // Start is called before the first frame update
    void Awake()
    {
        stats = GameObject.Find("EventSystem").GetComponent<Stats>();
        mainCanvas = GameObject.FindObjectOfType<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Place(int index)
    {
        try
        {
            CurrentTower.GetComponent<Tower>().FocusTower();
        }
        catch (UnassignedReferenceException)
        {
            CurrentTower = null;
            Debug.Log("Err, null");
        }
        catch (NullReferenceException)
        {
            CurrentTower = null;
            Debug.Log("Err, null");
        }
        if (CurrentTower == null)
        {
            switch (index)
            {
                case 0:
                    stats.AddMoney(-TowerSet[index].transform.GetChild(0).GetComponent<Building>().GetPrice());
                    CurrentTower = TowerSet[index];

                    break;
                case 1:
                    stats.AddMoney(-TowerSet[index].transform.GetChild(0).GetComponent<Building>().GetPrice());
                    CurrentTower = TowerSet[index];
                    break;
            }

            Instantiate(CurrentTower, transform.GetChild(0).transform.position, transform.GetChild(0).rotation);
        }

    }

    void OnMouseDown()
    {
        if (!alreadyPlaced)
        {
            mainCanvas.GetComponent<UIProcessing>().ShowTowerSelect(gameObject);
        }
    }

    public bool isPlaced()
    {
        if (alreadyPlaced)
            return true;
        else
            return false;
    }

    public void SetPlace(bool placed)
    {
        alreadyPlaced = placed;
    }

}
