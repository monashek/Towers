using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Towers/Enemy Data", order = 52)]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private Sprite mainSprite;

    [SerializeField]
    private float maxHp;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float damage;

    [SerializeField]
    private int minCost;

    [SerializeField]
    private int maxCost;

    public Sprite MainSprite
    {
        get
        {
            return mainSprite;
        }
    }

    public float MaxHp
    {
        get
        {
            return maxHp;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
    }

    public float Damage
    {
        get
        {
            return damage;
        }
    }

    public int MinCost
    {
        get
        {
            return minCost;
        }
    }

    public int MaxCost
    {
        get
        {
            return maxCost;
        }
    }
}
