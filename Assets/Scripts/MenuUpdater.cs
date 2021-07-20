using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuUpdater : MonoBehaviour
{
    public TextMeshProUGUI hpText;

    public TextMeshProUGUI moneyText;

    public TextMeshProUGUI wavesText;
    public SellTower towerSeller;
    public BuildTower towerBuilder;
    public EnemySpawner spawner;

    [SerializeField]
    private PlayerData data;

    public void HpUpdate()
    {
        hpText.text = "HP: " + data.CurrHp.ToString();
    }

    public void MoneyUpdate()
    {
        moneyText.text = "$: " + data.CurrMoneyCount.ToString();
    }

    public void WavesUpdate()
    {
        wavesText.text = "WAVES: " + spawner.CurrWave.ToString() + "/" + spawner.NumWaves.ToString();
    }
}
