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

    private Vector3 dir;
    public float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();

        positionsArray = positionCollection.GetComponentsInChildren<Transform>();


        foreach(var i in positionsArray)
        {
            Debug.Log(i.position.ToString() +  "    " + i.name);
        }

        myTransform.position = positionsArray[pivot].position;
        setDir();


    }

    // Update is called once per frame
    void Update()
    {
        

        myTransform.Translate(dir.normalized * Time.deltaTime * speed);

        Vector3 destPos = positionsArray[pivot + 1].position;
        Vector3 myPos = myTransform.position;

        Vector3 changeing = destPos - myPos;


        //if (changeing.normalized != new Vector3(dir.x, dir.y, dir.z).normalized)
        //{
        //    pivot += 1;
        //    Debug.Log("Pivot Plus");
        //    setDir();
        //}


        if (Mathf.Abs(destPos.x - myPos.x) < checkDistanceAmount
            && Mathf.Abs(destPos.y - myPos.y) < checkDistanceAmount)
        {
            pivot += 1;
            Debug.Log("Pivot Plus");
            setDir();
        }


    }

    void setDir()
    {
        if (pivot >= positionsArray.Length - 1)
        {
            Debug.Log("뭐가문제양");
            gameObject.GetComponent<EnemyMoving>().enabled = false;
            Destroy(gameObject);
            return;
        }
        Debug.Log("아ㅓㄴ제냐");
        dir = positionsArray[pivot + 1].position - positionsArray[pivot].position;
    }
}
