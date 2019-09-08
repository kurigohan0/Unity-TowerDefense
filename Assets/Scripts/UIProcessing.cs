using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIProcessing : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI WaveCounterText;
    private TextMeshProUGUI HealthText;

    void Awake()
    {
        WaveCounterText = GameObject.Find("WaveCounterText").GetComponent<TextMeshProUGUI>();
        HealthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        WaveCounterText.SetText("Wave: " + GameObject.FindObjectOfType<WaveSpawn>().GetWave().ToString());
        HealthText.SetText("Health: " + GameObject.FindObjectOfType<FinalPoint>().GetHP().ToString());

    }
}
