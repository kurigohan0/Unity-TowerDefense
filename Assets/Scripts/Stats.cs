using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int Money;

    // Update is called once per frame

    public int GetMoney()
    {
        return Money;
    }

    public void SetMoney(int money)
    {
        Money = money;
    }

    public void AddMoney(int money)
    {
        Money += money;
    }
}
