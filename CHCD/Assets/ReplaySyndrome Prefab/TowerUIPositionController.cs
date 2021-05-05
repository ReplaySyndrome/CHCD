using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUIPositionController : MonoBehaviour
{
    private bool isMoving = false;
    private bool isShowing = false;
    private bool isIncreasing = false;
    public RectTransform showRT;
    public RectTransform hideRT;
    public RectTransform UIRT;

    private float maxX = 170;
    private float minx = 0;
    private float currXpos = 170;
    private float speed = 170;

    // Start is called before the first frame update
    void Start()
    {
        UIRT.anchoredPosition = new Vector2(170, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving)
        {
            if(isIncreasing)
            {
                currXpos += Time.deltaTime * speed;
                if(currXpos > maxX)
                {
                    currXpos = maxX;
                    isMoving = false;
                }
            }
            else
            {
                currXpos -= Time.deltaTime * speed;
                if(currXpos < minx)
                {
                    currXpos = minx;
                    isMoving = false;
                }
            }

            UIRT.anchoredPosition = new Vector2(currXpos, 0);
        }
    }

    public void UIMove()
    {
        if (!isMoving)
        {
            if (!isShowing)
            {
                isShowing = true;
                isMoving = true;
                isIncreasing = false;
            }
            else
            {
                isShowing = false;
                isMoving = true;
                isIncreasing = true;
            }
        }
    }
}
