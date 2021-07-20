using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "Towers/Player Data", order = 53)]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private float maxHp;
    public float MaxHp
    {
        get
        {
            return maxHp;
        }

        set
        {
            maxHp = value;
        }
    }

    [SerializeField]
    private int moneyCount;
    public int MoneyCount
    {
        get
        {
            return moneyCount;
        }

        set
        {
            moneyCount = value;
        }
    }

    private float currHp;
    public float CurrHp
    {
        get
        {
            return currHp;
        }

        set
        {
            currHp = value;
        }
    }

    private int currMoneyCount;
    public int CurrMoneyCount
    {
        get
        {
            return currMoneyCount;
        }

        set
        {
            currMoneyCount = value;
        }
    }
}
