using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<WaveData> waveSettings;

    [SerializeField]
    private GameEvent waveEvent;

    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float delayTime;

    [SerializeField]
    private GameEvent youWin;

    public int NumWaves
    {
        get
        {
            return waveSettings.Count;
        }
    }

    private int currWave = 0;
    public int CurrWave
    {
        get
        {
            return currWave;
        }
    }

    private float waveTime;
    private bool lastWave = false;

    void Start()
    {
        waveEvent.Raise();
        StartCoroutine(StartTimer());
    }
    
    void Update()
    {
        if(lastWave)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if(enemies.Length <= 0)
            {
                youWin.Raise();
            }
        }
    }

    private IEnumerator Spawn()
    {
        while(waveTime > 0)
        {
            yield return new WaitForSeconds(waveSettings[currWave - 1].PauseTime);
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.GetComponent<Enemy>().Init(waveSettings[currWave - 1].EnemyType);
            waveTime -= waveSettings[currWave - 1].PauseTime;
        }

        if(currWave == waveSettings.Count)
        {
            lastWave = true;
        }
        else
        {
            StartCoroutine(StartTimer());
        }
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(delayTime);
        waveTime = waveSettings[currWave].WaveTime;
        currWave++;
        waveEvent.Raise();
        StartCoroutine(Spawn());
    }
}
