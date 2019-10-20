using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
