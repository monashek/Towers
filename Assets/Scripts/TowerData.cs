using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New TowerData", menuName = "Towers/Tower Data", order = 51)]
public class TowerData : ScriptableObject
{
    [SerializeField]
    private Sprite sprite;

    [SerializeField]
    private int towerBuildPrice;

    [SerializeField]
    private float range;

    [SerializeField]
    private float shootInterval;

    [SerializeField]
    private float damage;

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
    }

    public int TowerBuildPrice
    {
        get
        {
            return towerBuildPrice;
        }
    }

    public float Range
    {
        get
        {
            return range;
        }
    }

    public float ShootInterval
    {
        get
        {
            return shootInterval;
        }
    }

    public float Damage
    {
        get
        {
            return damage;
        }
    }
}