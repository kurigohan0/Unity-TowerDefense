using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Обработчик GUI
/// </summary>
public class UIProcessing : MonoBehaviour
{
    private TextMeshProUGUI WaveCounterText;
    private TextMeshProUGUI HealthText;
    private TextMeshProUGUI MoneyText;
    private RectTransform TowerSelectPanel;
    private Stats stats;
    private GameObject SelectedPlatform;
    private RectTransform InfoPanel;
    private RectTransform StatsPanel;
    private GameObject GameOverPanel;
    private GameObject LevelComplete;

    void Awake()
    {
        WaveCounterText = GameObject.Find("WaveCounterText").GetComponent<TextMeshProUGUI>();
        HealthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        MoneyText = GameObject.Find("MoneyText").GetComponent<TextMeshProUGUI>();
        TowerSelectPanel = GameObject.Find("TowerSelectPanel").GetComponent<RectTransform>();
        TowerSelectPanel.gameObject.SetActive(false);
        stats = GameObject.Find("EventSystem").GetComponent<Stats>();

        InfoPanel = GameObject.Find("InfoPanel").GetComponent<RectTransform>();
        StatsPanel = GameObject.Find("StatsPanel").GetComponent<RectTransform>();
        GameOverPanel = GameObject.Find("GameOverPanel");
        LevelComplete = GameObject.Find("LevelComplete");

        InfoPanel.gameObject.SetActive(false);
        StatsPanel.gameObject.SetActive(false);
        GameOverPanel.gameObject.SetActive(false);
        LevelComplete.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        WaveCounterText.SetText("Wave: " + GameObject.FindObjectOfType<WaveSpawn>().GetWave().ToString());
        HealthText.SetText("HP: " + GameObject.FindObjectOfType<FinalPoint>().GetHP().ToString() + " / 100" );
        MoneyText.SetText("Money: " + stats.GetMoney());
    }

    /// <summary>
    /// Отображение меню выбора башни
    /// </summary>
    /// <param name="selectedPlatform">Платформа</param>
    public void ShowTowerSelect(GameObject selectedPlatform)
    {
        TowerSelectPanel.gameObject.SetActive(true);
        SelectedPlatform = selectedPlatform;
    }

    /// <summary>
    /// Скрытие меню выбора башни
    /// </summary>
    public void HideTowerSelect()
    {
        SelectedPlatform = null; 
        TowerSelectPanel.gameObject.SetActive(false);
    }

    /// <summary>
    /// Отображение меню информации о башне
    /// </summary>
    /// <param name="tower">Башня</param>
    public void ShowInfoTower(Tower tower)
    {
        InfoPanel.gameObject.SetActive(true);
        GameObject.Find("TowerDescriptionText").GetComponent<TextMeshProUGUI>().SetText(tower.GetComponent<Tower>().Description);
        GameObject.Find("TowerNameText").GetComponent<TextMeshProUGUI>().SetText(tower.GetComponent<Tower>().Name);
    }

    /// <summary>
    /// Скрытие меню информации о башне
    /// </summary>
    public void HideInfoTower()
    {
        InfoPanel.gameObject.SetActive(false);
    }

    /// <summary>
    /// Отображение меню статов башни
    /// </summary>
    /// <param name="tower">Башня</param>
    public void ShowStatsTower(Tower tower)
    {
        StatsPanel.gameObject.SetActive(true);
        if (tower.GetLevel() < tower.UpgradeArray.Length - 1)
        {
            GameObject.Find("TowerStatsText").GetComponent<TextMeshProUGUI>().SetText($"Level: {tower.GetLevel().ToString()} \r\n " +
                                                                                      $"Damage: {tower.GetDamage().ToString()} \r\n\r\n Next upgrade \r\n Cost: {tower.UpgradeArray[tower.GetLevel()].Cost} \r\n" +
                                                                                      $"Damage: {tower.UpgradeArray[tower.GetLevel()].Damage}");
        }
        else
        {
            GameObject.Find("TowerStatsText").GetComponent<TextMeshProUGUI>().SetText("There is no updates more.");
        }
        GameObject.Find("TowerStatsNameText").GetComponent<TextMeshProUGUI>().SetText(tower.GetComponent<Tower>().Name);
    }

    /// <summary>
    /// Скрытие меню статов башни
    /// </summary>
    public void HideStatsTower()
    {
        StatsPanel.gameObject.SetActive(false);
    }

    /// <summary>
    /// Отображение сообщения что игра проиграна
    /// </summary>
    public void ShowGameOver()
    {
        GameOverPanel.gameObject.SetActive(true);
    }

    /// <summary>
    /// Отображение сообщения что игра выиграна
    /// </summary>
    public void ShowLevelComplete()
    {
        LevelComplete.gameObject.SetActive(true);
    }

    /// <summary>
    /// Обработка выбора обычной башни в меню выбора башни
    /// </summary>
    public void SelectedCommonTower()
    {
        if (stats.GetMoney() >= 10)
        {
            SelectedPlatform.GetComponent<TowerPlatform>().Place(0);
            TowerSelectPanel.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Перезапуск уровня
    /// </summary>
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Обработка выбора обычной башни в меню выбора башни
    /// </summary>
    public void SelectedAOETower()
    {
        if (stats.GetMoney() >= 50)
        {
            SelectedPlatform.GetComponent<TowerPlatform>().Place(1);
            TowerSelectPanel.gameObject.SetActive(false);
        }
    }
}
