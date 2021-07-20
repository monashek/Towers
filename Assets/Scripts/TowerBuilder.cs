using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerBuilder : MonoBehaviour
{
    public class ClickEvent : UnityEvent <GameObject> {}

    private ClickEvent clickEvent;

    void Start()
    {
        clickEvent = new ClickEvent();
        MenuUpdater updater = GameObject.Find("MainUI").GetComponent<MenuUpdater>();
        clickEvent.AddListener(updater.towerBuilder.ShowWindow);
    }

    private void OnMouseDown()
    {
        clickEvent.Invoke(this.gameObject);
    }
}
