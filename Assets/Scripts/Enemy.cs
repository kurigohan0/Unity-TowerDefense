using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    private float HP = 100;
    private float Damage = 10;

    private Transform target;
    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 1)
        {
            Destroy(gameObject);
        }
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 2f)
        {
            GetNextWaypoint();
        }

        if (HP < 30)
        {
            GetComponentInChildren<HPBar>().SetColor(new Color(200, 0, 0));
        }
        else
        {
            GetComponentInChildren<HPBar>().SetColor(GetComponentInChildren<HPBar>().GetDefaultColor());
        }
        GetComponentInChildren<Image>().fillAmount = GetHp() / 100;
    }

    private void GetNextWaypoint()
    {
        if (Waypoints.points[waypointIndex].name == "FinalPoint")
        {
            GameObject.Find("FinalPoint").GetComponent<FinalPoint>().SetHP(GameObject.Find("FinalPoint").GetComponent<FinalPoint>().GetHP()-GetDamage());
            Destroy(gameObject);
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    public void SetDamage(float damage)
    {
        HP = HP - damage;
    }

    public float GetHp()
    {
        return HP;
    }

    public float GetDamage()
    {
        return Damage;
    }
}
