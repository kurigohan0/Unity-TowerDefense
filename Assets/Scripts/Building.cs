using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    protected int Price;
    [SerializeField]
    protected string Name;
    [SerializeField]
    protected GameObject BuildingObject;
    private GameObject Platform;
    private Stats stats;

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
        Debug.Log("Destroy");
        Camera.main.GetComponent<CameraController>().ReturnToDefaultPosition();
        stats = GameObject.Find("EventSystem").GetComponent<Stats>();
        stats.AddMoney(GetPrice()/2);
        Destroy(BuildingObject, 0f);
    }

    public void SetPlatform(GameObject platform)
    {
        Debug.Log("-----" + Platform.name);
        Platform = platform;
    }
}
