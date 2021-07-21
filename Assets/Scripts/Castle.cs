using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public PlayerData data;

    [SerializeField]
    private GameEvent hitEvent;

    [SerializeField]
    private GameEvent moneyEvent;

    [SerializeField]
    private GameEvent gameOverEvent;
    
    void Start()
    {
        data.CurrHp = data.MaxHp;
        data.CurrMoneyCount = data.MoneyCount;
        hitEvent.Raise();
        moneyEvent.Raise();
    }

    public void Hit(float damage)
    {
        data.CurrHp -= damage;

        if(data.CurrHp < 0)
        {
            data.CurrHp = 0;
            gameOverEvent.Raise();
        }

        hitEvent.Raise();
    }

    public void MoneyAdd(int cost)
    {
        data.CurrMoneyCount += cost;
        moneyEvent.Raise();
    }

    public void MoneyDec(int cost)
    {
            data.CurrMoneyCount -= cost;
            moneyEvent.Raise();
    }
}
