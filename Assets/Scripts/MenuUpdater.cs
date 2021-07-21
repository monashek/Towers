using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUpdater : MonoBehaviour
{
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI wavesText;
    public TextMeshProUGUI gameText;
    public Button reloadButton;
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

    public void OnGameOver()
    {
        gameText.gameObject.SetActive(true);
        reloadButton.gameObject.SetActive(true);
    }

    public void OnWinGame()
    {
        gameText.text = "You Win";
        gameText.gameObject.SetActive(true);
        reloadButton.gameObject.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Game");
    }
}
