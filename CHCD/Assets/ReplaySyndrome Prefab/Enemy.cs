using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 100;
    public float mp = 100;
    public float physicsDefensivePower = 0f;
    public float magicDefensivePoser = 0f;

    private bool isDead = false;
    public bool IsDead 
    {
        get
        {
            return isDead;
        }
        
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UnderAttack(float damage,bool isPhysicsType)
    { 
        if(isPhysicsType)
        {
            hp -= damage *  (1 - (physicsDefensivePower / 100f));
        }
        else
        {
            hp -= damage *(1 - ( magicDefensivePoser / 100f ));
        }

        if(hp <= 0)
        {
            Destroy(gameObject, 10f);
            gameObject.SetActive(false);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            isDead = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            UnderAttack(other.GetComponent<Bullet>().Damage, other.GetComponent<Bullet>().isPhysical);
        }
    }
}
