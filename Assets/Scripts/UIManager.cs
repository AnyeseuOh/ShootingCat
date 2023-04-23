using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    CatController catController;
    
    public Text scoreText;
    public Text hpText;

    void Start()
    {
        catController = GameObject.Find("Cat").GetComponent<CatController>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE : " + catController.score.ToString("00000");
        hpText.text = " :  "+ catController.catHp.ToString("00");
    }
}
