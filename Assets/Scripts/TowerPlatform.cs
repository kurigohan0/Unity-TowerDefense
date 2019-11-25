using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс платформы для башни
/// </summary>
public class TowerPlatform : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] TowerSet = new GameObject[2];
    private bool alreadyPlaced = false;
    private Canvas mainCanvas;
    private Stats stats;
    [SerializeField]
    public GameObject CurrentTower;

    void Awake()
    {
        stats = GameObject.Find("EventSystem").GetComponent<Stats>();
        mainCanvas = GameObject.FindObjectOfType<Canvas>();
    }

    /// <summary>
    /// Установка башни
    /// </summary>
    /// <param name="index">Индекс типа башни</param>
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

    /// <summary>
    /// Проверка на уже установленную башню
    /// </summary>
    /// <returns></returns>
    public bool isPlaced()
    {
        if (alreadyPlaced)
            return true;
        else
            return false;
    }

    /// <summary>
    /// Фиксация установки башни
    /// </summary>
    /// <param name="placed">Установлена ли башня</param>
    public void SetPlace(bool placed)
    {
        alreadyPlaced = placed;
    }

}
