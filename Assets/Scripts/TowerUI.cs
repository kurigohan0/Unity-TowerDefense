using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    SpriteRenderer sr;
    [SerializeField]
    private GameObject TowerUIElement;
    [SerializeField]
    private Button BackButton;
    
    // Start is called before the first frame update
    void Awake()
    {
        sr = TowerUIElement.GetComponent<SpriteRenderer>();
        BackButton = GetComponentInChildren<Button>();
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
        BackButton.enabled = true;
    }

    internal void HideUI()
    {
        sr.enabled = false;
        BackButton.enabled = false;

    }
}
