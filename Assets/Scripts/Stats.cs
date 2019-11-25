using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Общая игровая статистика
/// </summary>
public class Stats : MonoBehaviour
{
    [SerializeField]
    private int Money;

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
