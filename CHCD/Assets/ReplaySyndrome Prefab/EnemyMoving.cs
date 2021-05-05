using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMoving : MonoBehaviour
{


    public Transform positionCollection;

    private Transform myTransform;
    private int pivot = 1;
    private Transform[] positionsArray;
    private float checkDistanceAmount = 0.1f;
    private SpriteRenderer sr;
    private Vector3 dir;
    public float speed = 1.5f;


    public float xAxisVariation;
    public float yAxisVariation;

    private void Awake()
    {
        
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        positionCollection = GameObject.FindGameObjectWithTag("MonsterWay").GetComponent<Transform>();

        xAxisVariation = UnityEngine.Random.Range(-3.0f, 3.0f);
        yAxisVariation = UnityEngine.Random.Range(-3.0f, 3.0f);

        myTransform = GetComponent<Transform>();
        positionCollection.position = Vector3.zero;
        positionsArray = positionCollection.GetComponentsInChildren<Transform>();


        //foreach(var i in positionsArray)
        //{
        //    Debug.Log(i.position.ToString() +  "    " + i.name);
        //}

        myTransform.position = positionsArray[pivot].position;
        setDir();


    }

    // Update is called once per frame
    void Update()
    {

       // Vector3 translateddir = dir + new Vector3(xAxisVariation, yAxisVariation, 0);


        myTransform.Translate(dir.normalized * Time.deltaTime * speed);
        Vector3 destPos = positionsArray[pivot + 1].position;       
        Vector3 myPos = myTransform.position;
        Vector3 changeing = destPos - myPos;
        if (Mathf.Abs(destPos.x  - myPos.x) < checkDistanceAmount
            && Mathf.Abs(destPos.y - myPos.y) < checkDistanceAmount)
        {
            pivot += 1;
            //Debug.Log("Pivot Plus");
            setDir();
        }
        

    }

    void setDir()
    {
        if (pivot >= positionsArray.Length - 1)
        {
            gameObject.GetComponent<EnemyMoving>().enabled = false;
            Destroy(gameObject);
            return;
        }
        dir = positionsArray[pivot + 1].position - positionsArray[pivot].position;


        if (dir.x > 0)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }

}

