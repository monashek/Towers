using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    public class ClickEvent : UnityEvent <GameObject> {}

    public GameObject bulletPrefab;

    private ClickEvent clickEvent;
    private GameObject currTarget;
    public GameObject CurrTarget
    {
        get
        {
            return currTarget;
        }
    }
    private TowerData data;
    private float shootTime = 0;
    private bool active = false;

    public TowerData Data
    {
        get
        {
            return data;
        }

        set
        {
            data = value;
            shootTime = data.ShootInterval;
        }
    }

    void Start()
    {
        clickEvent = new ClickEvent();
        MenuUpdater updater = GameObject.Find("MainUI").GetComponent<MenuUpdater>();
        clickEvent.AddListener(updater.towerSeller.ShowWindow);
    }

    void Update()
    {
        if(!active)
        {
            shootTime -= Time.deltaTime;
            if(shootTime <= 0)
            {
                active = true;
                shootTime = data.ShootInterval;
            }
        }

        if(active)
        {
            currTarget = SortTarget();
            if(currTarget != null)
            {
                float dist = Vector2.Distance(currTarget.transform.position, transform.position);

                if(dist <= data.Range)
                {
                    GameObject bullet = GameObject.Instantiate(bulletPrefab);
                    bullet.transform.position = transform.position;
                    bullet.GetComponent<Bullet>().Init(this);
                    active = false;
                }
                else
                {
                    currTarget = null;
                }
            }
        }
    }

    private GameObject SortTarget()
    {
        float minDistance = 1000;
        GameObject target = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemies)
        {
            float dist = Vector2.Distance(enemy.transform.position, transform.position);
            if(dist < minDistance)
            {
                minDistance = dist;
                target = enemy;
            }
        }

        return target;
    }

    void OnMouseDown()
    {
        clickEvent.Invoke(this.gameObject);
    }
}
