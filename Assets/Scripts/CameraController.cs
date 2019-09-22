using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//старый код был тут https://kylewbanks.com/blog/unity3d-panning-and-pinch-to-zoom-camera-with-touch-and-mouse-input

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
