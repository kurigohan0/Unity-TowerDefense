using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatform : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] TowerSet = new GameObject[2];
    private bool alreadyPlaced = false;
    private Canvas mainCanvas;
    private Stats stats;

    // Start is called before the first frame update
    void Awake()
    {
        stats = GameObject.Find("EventSystem").GetComponent<Stats>();
        mainCanvas = GameObject.FindObjectOfType<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Place(int index)
    {
        switch (index)
        {
            case 0:
                stats.AddMoney(-10);
                break;
            case 1:
                stats.AddMoney(-50);
                break;
        }
        if (!alreadyPlaced)
        {
            Debug.Log("Place");
            alreadyPlaced = true;

            Instantiate(TowerSet[index], transform.GetChild(0).transform.position, transform.GetChild(0).rotation);
        }
    }

    void OnMouseDown()
    {
        if (!alreadyPlaced)
        {
            
            mainCanvas.GetComponent<UIProcessing>().ShowTowerSelect(gameObject);
        }
    }

}
