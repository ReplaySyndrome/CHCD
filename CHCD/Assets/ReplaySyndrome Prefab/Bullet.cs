using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    GameObject target;
    public float speed = 10f;
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

    private float damage = 100f;
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
        Vector3 dir = target.transform.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * speed);
        if (Vector3.Distance(target.transform.position, transform.position) < minDistance)
        {
            
            target.GetComponent<Enemy>().UnderAttack(damage, isPhysical);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

   

}
