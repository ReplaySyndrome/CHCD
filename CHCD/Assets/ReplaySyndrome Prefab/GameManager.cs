using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MonsterPrefab;

    public float coolTime = 0.0f;
    private float deltatime = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deltatime += Time.deltaTime;
        if(deltatime > coolTime)
        {
            Instantiate(MonsterPrefab);
            deltatime = 0;
            coolTime = Random.Range(1.0f,3.0f);
        }
    }
}
