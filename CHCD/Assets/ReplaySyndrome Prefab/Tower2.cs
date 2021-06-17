using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : MonoBehaviour
{
    protected float cooltime = 1.5f;
    protected float delaiedtime = 3f;
    public float attackRange = 30f;

    private List<Enemy> enemies;

    public GameObject bullet;

    protected string className = "Tower2";

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (delaiedtime > cooltime)
        {
            if (enemies.Count > 0)
            {
                if (!enemies[0].GetComponent<Enemy>().IsDead)
                {
                    //Vector3 enemyPos = enemies[i].transform.position;
                    GameObject o = Instantiate(bullet, gameObject.transform);
                    o.GetComponent<Bullet>().Target = null;

                    o = Instantiate(bullet, gameObject.transform);
                    o.GetComponent<Bullet>().Target = null;
                    o.GetComponent<Bullet>().dir = Vector2.down;

                    o = Instantiate(bullet, gameObject.transform);
                    o.GetComponent<Bullet>().Target = null;
                    o.GetComponent<Bullet>().dir = Vector2.up;

                    o = Instantiate(bullet, gameObject.transform);
                    o.GetComponent<Bullet>().Target = null;
                    o.GetComponent<Bullet>().dir = Vector2.right;

                    o = Instantiate(bullet, gameObject.transform);
                    o.GetComponent<Bullet>().Target = null;
                    o.GetComponent<Bullet>().dir = Vector2.left;

                    o = Instantiate(bullet, gameObject.transform);
                    o.GetComponent<Bullet>().Target = null;
                    o.GetComponent<Bullet>().dir = Vector2.left + Vector2.up;

                    o = Instantiate(bullet, gameObject.transform);
                    o.GetComponent<Bullet>().Target = null;
                    o.GetComponent<Bullet>().dir = Vector2.up + Vector2.right;


                    o = Instantiate(bullet, gameObject.transform);
                    o.GetComponent<Bullet>().Target = null;
                    o.GetComponent<Bullet>().dir = Vector2.down + Vector2.right;

                    o = Instantiate(bullet, gameObject.transform);
                    o.GetComponent<Bullet>().Target = null;
                    o.GetComponent<Bullet>().dir = Vector2.down + Vector2.left;



                    delaiedtime = 0;
                }
            }

            //Physics2D.OverlapCircleAll(transform.position, attackRange,13);
            //Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRange);



            //멀리온놈을 배열맨앞으로배치한다. 근데찾기랑 정렬을 이렇게 조져도 될까? 되겠지
            /* GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
             Array.Sort(enemies,(a,b) => (a.GetComponent<EnemyMoving>().MoveDistance < b.GetComponent<EnemyMoving>().MoveDistance) ? -1:1);


             for(int i=0;i<enemies.Length;++i)
             {               
                 if(Vector3.Distance(enemies[i].transform.position, transform.position) < attackRange)
                 {

                     if (!enemies[i].GetComponent<Enemy>().IsDead)
                     {
                         //Vector3 enemyPos = enemies[i].transform.position;
                         GameObject o = Instantiate(bullet, gameObject.transform);
                         o.GetComponent<Bullet>().Target = enemies[i];
                         delaiedtime = 0;
                         break;
                     }
                 }
             }*/
        }

        Debug.DrawRay(transform.position, Vector3.right * attackRange, Color.red);
        delaiedtime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemies.Add(enemy);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        var enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemies.Remove(enemy);
        }
    }

}
