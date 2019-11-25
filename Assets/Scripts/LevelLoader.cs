using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Переключение уровней
/// </summary>
public class LevelLoader : MonoBehaviour
{
    /// <summary>
    /// Загрузка первого уровня
    /// </summary>
    public void LoadLevel1()
    {
        SceneManager.LoadScene("1"); 
    }

    /// <summary>
    /// Загрузка главного меню
    /// </summary>
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
