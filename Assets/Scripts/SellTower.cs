using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SellTower : MonoBehaviour
{
    public Castle castle;
    public TextMeshProUGUI costText;
    public GameObject builderPrefab;
    private GameObject towerObject;

    public void ShowWindow(GameObject tower)
    {
        towerObject = tower;
        transform.position = towerObject.transform.position;
        costText.text = (towerObject.GetComponent<Tower>().Data.TowerBuildPrice / 2).ToString();
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void TowerSell()
    {
        GameObject builder = GameObject.Instantiate(builderPrefab);
        builder.transform.parent = towerObject.transform.parent;
        builder.transform.position = towerObject.transform.position;
        castle.MoneyAdd(towerObject.GetComponent<Tower>().Data.TowerBuildPrice / 2);
        Destroy(towerObject);
        gameObject.SetActive(false);
    }
}
