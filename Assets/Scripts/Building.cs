using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, описывающий постройки
/// </summary>
public class Building : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    protected int Price;
    [SerializeField]
    public string Name;
    [SerializeField]
    public string Description;
    [SerializeField]
    protected GameObject BuildingObject;
    private GameObject Platform;
    protected Stats stats;

    public int GetPrice()
    {
        return Price;
    }

    public void SetPrice(int price)
    {
        Price = price;
    }

    public string GetName()
    {
        return Name;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void Sell()
    {
        Camera.main.GetComponent<CameraController>().ReturnToDefaultPosition();
        stats = GameObject.Find("EventSystem").GetComponent<Stats>();
        stats.AddMoney(GetPrice()/2);
        Destroy(BuildingObject, 0f);
    }
    /// <summary>
    /// Устанавливает платформу для башни
    /// </summary>
    /// <param name="platform">Платформа для башни</param>
    public void SetPlatform(GameObject platform)
    {
        Platform = platform;
    }
}
