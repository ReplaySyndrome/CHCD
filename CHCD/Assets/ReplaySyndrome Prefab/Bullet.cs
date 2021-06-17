using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    GameObject target;
    public float speed = 10f;

    private float madeTime;

    public Vector3 dir;
    public GameObject Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }

    private float damage = 30f;
    public float Damage
    {
        get
        {
            return damage;
        }
    }

    public bool isPhysical = true;

    float minDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

   
        if (target == null)
        {
            madeTime += Time.deltaTime;

            if (madeTime > 0.5f)
            {
                Destroy(gameObject);
                return;
            }
            if (madeTime - Time.time < 3)
            {
                transform.Translate(dir.normalized * Time.deltaTime * speed);
                
            }
            else
            {
                Destroy(gameObject);
            }
        }

        else
        {
            dir = target.transform.position - transform.position;
            transform.Translate(dir.normalized * Time.deltaTime * speed);
            if (Vector3.Distance(target.transform.position, transform.position) < minDistance)
            {

                target.GetComponent<Enemy>().UnderAttack(damage, isPhysical);
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(target == null)
        {
            collision.GetComponent<Enemy>().UnderAttack(damage - 10, false);
            
        }
        
    }



}
