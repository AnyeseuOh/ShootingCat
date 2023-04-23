using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TitleCatController : MonoBehaviour
{

    public GameObject cat;
    public float moveSpd = 0.1f;

    void Start()
    {
        DOTween.Init();
    }

    void Update()
    {
        Run();
        if (cat.transform.position.x > 10.3f)
        {
            moveSpd = -moveSpd;
            cat.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (cat.transform.position.x < -10.3f)
        {
            moveSpd = -moveSpd;
            cat.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    public void Run()
    {
        cat.transform.Translate(moveSpd * Time.timeScale, 0, 0);
    }

}
