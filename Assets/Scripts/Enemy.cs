using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float EnemySpeed = 10f;
    [SerializeField]
    protected float HP = 100;
    [SerializeField]
    protected float EnemyDamage = 10;
    [SerializeField]
    private int minBounty;
    [SerializeField]
    private int maxBounty;
    private Stats stats;
    private bool stop;

    private Transform TargetWaypoint;
    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        TargetWaypoint = Waypoints.points[0];
        stats = GameObject.Find("EventSystem").GetComponent<Stats>();
        stop = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(!stop)
            Move();
        HPBehaviour();
    }

    public void Stop()
    {
        stop = true;
    }

    private void Move()
    {
        Vector3 dir = TargetWaypoint.position - transform.position;
        transform.Translate(dir.normalized * EnemySpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, TargetWaypoint.position) <= 2f)
        {
            GetNextWaypoint();
        }
    }

    public int GetBounty()
    {
        return Random.Range(minBounty, maxBounty);
    }

    private void HPBehaviour()
    {
        if (HP < 30)
        {
            GetComponentInChildren<HPBar>().SetColor(new Color(200, 0, 0));
            if (HP < 1)
            {
                stats.AddMoney(GetBounty());
                Destroy(gameObject);
            }
        }
        else
        {
            GetComponentInChildren<HPBar>().SetColor(GetComponentInChildren<HPBar>().GetDefaultColor());
        }
        GetComponentInChildren<Image>().fillAmount = GetHp() / 100;
        GetComponentInChildren<Image>().fillOrigin = 1;

    }

    private void GetNextWaypoint()
    {
        if (Waypoints.points[waypointIndex].name == "FinalPoint")
        {
            GameObject.Find("FinalPoint").GetComponent<FinalPoint>().SetHP(GameObject.Find("FinalPoint").GetComponent<FinalPoint>().GetHP()-GetDamage());
            Destroy(gameObject);
        }
        waypointIndex++;
        TargetWaypoint = Waypoints.points[waypointIndex];
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
        return EnemyDamage;
    }

    public void SetSpeed(float speed)
    {
        EnemySpeed = speed;
    }

    public float GetSpeed()
    {
        return EnemySpeed;
    }
}
