using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float curTime = 0;
    public float coolTime;
    public bool isComplete = false;
    void Start()
    {
        
    }

    
    void Update()
    {

        curTime += Time.deltaTime;
        if (curTime > coolTime)
        {
            curTime = 0;
            isComplete = true;
        }
    }

    public float TimerInt(float cTime)
    {
        return coolTime = cTime;
    }
}
