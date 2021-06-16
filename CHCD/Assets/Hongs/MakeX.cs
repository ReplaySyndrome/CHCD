using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeX : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    void Start()
    {
        Instantiate(obj, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, -1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
