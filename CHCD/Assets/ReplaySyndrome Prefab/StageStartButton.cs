using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageStartButton : MonoBehaviour
{

    private GameManager gameManager;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (gameManager.coolTime  - gameManager.deltatime < 100)
        {
            text.text = Convert.ToInt32(gameManager.coolTime - gameManager.deltatime).ToString();
        }
    }

    private void OnEnable()
    {
        text.text = "GameStart";
    }

}
