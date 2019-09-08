using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float HP;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHP(float hp)
    {
        HP = hp;
    }

    public float GetHP()
    {
        return HP;
    }
}
