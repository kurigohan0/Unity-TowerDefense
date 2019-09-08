using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatform : MonoBehaviour
{
    public GameObject Tower;
    private bool alreadyPlaced = false;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Place()
    {
 
        Instantiate(Tower, transform.GetChild(0).transform.position, transform.GetChild(0).rotation);
        
    }

    void OnMouseDown()
    {
        if (!alreadyPlaced)
        {
            Place();
            alreadyPlaced = true;
        }
    }
}
