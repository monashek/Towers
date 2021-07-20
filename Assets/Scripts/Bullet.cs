using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Tower creator;
    private float speed = 5;

    public void Init(Tower creator)
    {
        this.creator = creator;
    }

    void Start()
    {
    }

    void Update()
    {
        if(creator != null)
        {
            if(creator.CurrTarget == null)
            {
                GameObject.Destroy(gameObject);
                return;
            }

            Vector2 dir = (creator.CurrTarget.transform.position - transform.position).normalized;
            float dist = Vector2.Distance(creator.CurrTarget.transform.position, transform.position);

            if(dist > (speed * Time.deltaTime))
            {
                transform.Translate(dir * speed * Time.deltaTime);
            }
            else
            {
                Enemy enemy = creator.CurrTarget.GetComponent<Enemy>();
                enemy.Hit(creator.Data.Damage);
                GameObject.Destroy(gameObject);
            }
        }
    }
}
