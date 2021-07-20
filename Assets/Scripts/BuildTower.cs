using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildTower : MonoBehaviour
{
    public Castle castle;
    public TextMeshProUGUI tower1Text;
    public TextMeshProUGUI tower2Text;
    public TextMeshProUGUI tower3Text;
    public TextMeshProUGUI tower4Text;
    public GameObject towerPrefab;

    [SerializeField]
    private List<TowerData> towersData;

    private GameObject towerBuilder;

    public void ShowWindow(GameObject builder)
    {
        towerBuilder = builder;
        transform.position = towerBuilder.transform.position;
        tower1Text.text = towersData[0].TowerBuildPrice.ToString();
        tower2Text.text = towersData[1].TowerBuildPrice.ToString();
        tower3Text.text = towersData[2].TowerBuildPrice.ToString();
        tower4Text.text = towersData[3].TowerBuildPrice.ToString();
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void CreateTower(TowerData data)
    {
        if(castle.data.CurrMoneyCount >= data.TowerBuildPrice)
        {
            GameObject tower = GameObject.Instantiate(towerPrefab);
            tower.GetComponent<SpriteRenderer>().sprite = data.Sprite;
            tower.GetComponent<Tower>().Data = data;
            tower.transform.parent = towerBuilder.transform.parent;
            tower.transform.position = towerBuilder.transform.position;
            Destroy(towerBuilder);
            castle.MoneyDec(data.TowerBuildPrice);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Not enough money");
        }
    }
}
