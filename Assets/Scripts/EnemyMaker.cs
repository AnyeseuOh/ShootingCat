using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMaker : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float curTime = 0;
    public float rndTime;
    public int rndIndex;


    void Start()
    {
        RandomTime();
    }

    
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > rndTime)
        {
            curTime = 0;
            Instantiate(enemyPrefab[rndIndex], transform.position, transform.rotation);
            RandomTime();
        }
        
    }

    public void RandomTime()
    {
        rndTime = Random.Range(0.5f, 3f);
        rndIndex = Random.Range(0, 3);
    }
}
