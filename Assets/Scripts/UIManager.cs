using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    CatController catController;
    
    public Text scoreText;

    void Start()
    {
        catController = GameObject.Find("Cat").GetComponent<CatController>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("SCORE : {0:D5}", catController.score.ToString());
        
    }
}
