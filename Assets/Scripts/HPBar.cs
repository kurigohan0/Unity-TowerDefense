using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Color DefaultColor;
    void Start()
    {
        GetComponent<Image>().color = DefaultColor;
    }

    // Update is called once per frame
    void Update()
    {
        Transform cameraPos = Camera.main.transform;
        transform.LookAt(new Vector3(transform.position.x, cameraPos.position.y, cameraPos.position.z));
    }

    public void SetColor(Color color)
    {
        GetComponent<Image>().color = color;

    }

    public Color GetColor()
    {
        Color color = GetComponent<Image>().color;
        return color;
    }

    public Color GetDefaultColor()
    {
        return DefaultColor;
    }
}
