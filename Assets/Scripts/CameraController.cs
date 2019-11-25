using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс контроллера камеры
/// </summary>
public class CameraController : MonoBehaviour
{
    public bool isFocusing { get; set; }
    [SerializeField]
    private Vector3 DefaultPosition;

    private GameObject FocusPoint { get; set; }

    void Start()
    {
        isFocusing = false;
    }

    void Update()
    {
        if (isFocusing)
        {
            transform.position = Vector3.Lerp(Camera.main.transform.position, FocusPoint.transform.position, Time.deltaTime * 20);
        }
        else
        {
            transform.position = Vector3.Lerp(Camera.main.transform.position, DefaultPosition, Time.deltaTime * 20);
        }
    }

    /// <summary>
    /// Устанавливает фокусную точку, куда будет стремиться камера
    /// </summary>
    /// <param name="focusPoint">Фокусная точка</param>
    public void GoToFocusPoint(GameObject focusPoint)
    {
        FocusPoint = focusPoint;
        isFocusing = true;
    }

    public void ReturnToDefaultPosition()
    {
        isFocusing = false;
    }
}
