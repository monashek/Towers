using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[CreateAssetMenu(fileName = "New WaveData", menuName = "Towers/Wave Data", order = 54)]
public class WaveData : ScriptableObject
{
    [SerializeField]
    private float waveTime;
    public float WaveTime
    {
        get
        {
            return waveTime;
        }
    }

    [SerializeField]
    private float pauseTime;
    public float PauseTime
    {
        get
        {
            return pauseTime;
        }
    }

    [SerializeField]
    private EnemyData enemyType;
    public  EnemyData EnemyType
    {
        get
        {
            return enemyType;
        }
    }
}
