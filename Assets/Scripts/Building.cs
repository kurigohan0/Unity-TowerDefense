using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    protected float Price;
    [SerializeField]
    protected string Name;

    public float GetPrice()
    {
        return Price;
    }

    public void SetPrice(float price)
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
}
