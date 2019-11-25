using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Интерфейс башни
/// </summary>
public class TowerUI : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField]
    private GameObject TowerUIElement;
    [SerializeField]
    private Button BackButton;
    [SerializeField]
    private Button UpgradeButton;
    [SerializeField]
    private Button SellButton;
    [SerializeField]
    private Button StatsButton;
    [SerializeField]
    private Button DestroyButton;
    [SerializeField]
    private Button InfoButton;

    /// <summary>
    /// Получение кнопок в меню
    /// </summary>
    void Awake()
    {
        sr = TowerUIElement.GetComponent<SpriteRenderer>();
        BackButton = GetComponentInChildren<Button>();
        UpgradeButton = GetComponentInChildren<Button>();
        SellButton = GetComponentInChildren<Button>();
        StatsButton = GetComponentInChildren<Button>();
        DestroyButton = GetComponentInChildren<Button>();
        StatsButton = GetComponentInChildren<Button>();
        sr.enabled = true;
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Transform cameraPos = Camera.main.transform;
        transform.LookAt(new Vector3(transform.position.x, cameraPos.position.y, cameraPos.position.z));
    }

    public void ShowUI()
    {
        sr.enabled = true;
        ButtonState(true);
    }

    internal void HideUI()
    {
        sr.enabled = false;
        ButtonState(false);
    }

    /// <summary>
    /// Включение или отключение кнопок
    /// </summary>
    /// <param name="State">Положение</param>
    private void ButtonState(bool State)
    {
        BackButton.enabled = State;
        UpgradeButton.enabled = State;
        SellButton.enabled = State;
        StatsButton.enabled = State;
        DestroyButton.enabled = State;
        InfoButton.enabled = State;
    }
}
