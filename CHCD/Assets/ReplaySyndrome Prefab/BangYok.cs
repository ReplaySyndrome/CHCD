using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BangYok : MonoBehaviour
{
    public float deltaTime = 0;
    float coolTime = 5;
    public CircleCollider2D col;
    public SpriteRenderer[] sprites;


    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<CircleCollider2D>();
        col.enabled = false;

        sprites[2].enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        deltaTime += Time.deltaTime;
        if(deltaTime > coolTime)
        {

            print("방역해야함");

            sprites[0].enabled = false;
            sprites[1].enabled = false;

            col.enabled = true;
            sprites[2].enabled = true;
        }   
    }


}
