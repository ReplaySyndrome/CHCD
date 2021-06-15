using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllFade : MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject go;

    float timer = 0.0f;
    public float waitingTime = 1f;
    public float firstTime = 3f;
    bool checking;
    bool inside;
    // Start is called before the first frame update
    void Start()
    {
        sr = go.GetComponent<SpriteRenderer>();
        Color c = sr.material.color;
        c.a = 0.0f;
        sr.material.color = c;
        inside = true;
        checking = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > firstTime)
            checking = true;
    
        if(checking)
        {
            if (timer > waitingTime && inside)
            {
                //Action
                StartCoroutine("Fadein");
                inside = false;
                timer = 0f;
            }
            if (timer > waitingTime && !inside)
            {
                StartCoroutine("Fadeout");
                inside = true;
                timer = 0f;
            }
        }
    }

    IEnumerator Fadein()
    {
        for (int i = 0; i < 9; i++)
        {
            float f = i / 10.0f;
            Color c = sr.material.color;
            c.a = f;
            sr.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Fadeout()
    {
        for (int i = 10; i > 0; i--)
        {
            float f = i / 10.0f;
            Color c = sr.material.color;
            c.a = f;
            sr.material.color = c;
            yield return new WaitForSeconds(0.1f);
        }
    }


}
