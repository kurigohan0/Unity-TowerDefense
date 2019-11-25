using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс для полоски здоровья над врагами
/// </summary>
public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    private FinalPoint HPObject;
    private Image image;
    void Start()
    {
        HPObject = GameObject.FindObjectOfType<FinalPoint>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = HPObject.GetHP() / 100;
    }
}
