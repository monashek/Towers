using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Path path;
    private Transform nextPoint;
    private int numPoint = 0;
    private EnemyData data;
    private float hp;

    public void Init(EnemyData _data)
    {
        data = _data;
        hp = data.MaxHp;
        GetComponent<SpriteRenderer>().sprite = data.MainSprite;
        path = GameObject.Find("Path").GetComponent<Path>();
        nextPoint = path.pathPoints[numPoint++];
    }

    void Update()
    {
        Vector2 dir = nextPoint.position - transform.position;
        float dist = Vector2.Distance(nextPoint.position, transform.position);
        if(dist > (Time.deltaTime * data.Speed))
        {
            transform.Translate(dir.normalized * Time.deltaTime * data.Speed);
        }
        else
        {
            transform.position = nextPoint.position;
            if(numPoint < path.pathPoints.Length)
            {
                nextPoint = path.pathPoints[numPoint++];
            }
            else
            {
                Castle castle = GameObject.Find("Castle").GetComponent<Castle>();
                castle.Hit(data.Damage);
                GameObject.Destroy(gameObject);
            }
        }
    }

    public void Hit(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            GameObject.Destroy(gameObject);
            Castle castle = GameObject.Find("Castle").GetComponent<Castle>();
            castle.MoneyAdd(Random.Range(data.MinCost, data.MaxCost));
        }
    }
}
