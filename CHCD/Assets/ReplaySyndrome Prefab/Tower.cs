using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Tower : MonoBehaviour
{
    protected float cooltime = 1f;
    protected float delaiedtime = 3f;
    public float attackRange = 30f;

    public GameObject bullet;
   
    protected string className = "BasicTower";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(delaiedtime > cooltime)
        {

            //Physics2D.OverlapCircleAll(transform.position, attackRange,13);
            //Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange);



            //�ָ��³��� �迭�Ǿ����ι�ġ�Ѵ�. �ٵ�ã��� ������ �̷��� ������ �ɱ�? �ǰ���
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
            Array.Sort(enemies,(a,b) => (a.GetComponent<EnemyMoving>().MoveDistance < b.GetComponent<EnemyMoving>().MoveDistance) ? -1:1);

            
            for(int i=0;i<enemies.Length;++i)
            {               
                if(Vector3.Distance(enemies[i].transform.position, transform.position) < attackRange)
                {
                    print(!enemies[i].GetComponent<Enemy>().IsDead);
                    if (!enemies[i].GetComponent<Enemy>().IsDead)
                    {
                        print("�߻�!");
                        //Vector3 enemyPos = enemies[i].transform.position;
                        GameObject o = Instantiate(bullet, gameObject.transform);
                        o.GetComponent<Bullet>().Target = enemies[i];
                        delaiedtime = 0;
                        break;
                    }
                }
            }
        }

        Debug.DrawRay(transform.position, Vector3.right * attackRange,Color.red);
        delaiedtime += Time.deltaTime;
    }


}
