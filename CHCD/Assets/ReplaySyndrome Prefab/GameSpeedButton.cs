using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpeedButton : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetAccerlation(float a)
    {
        gameManager.acceleration = a;
    }
}
