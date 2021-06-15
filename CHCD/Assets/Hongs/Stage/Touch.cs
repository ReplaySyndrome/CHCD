using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)==true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit;
          
           
        }
        if (Input.GetMouseButtonUp(0) == true)
        {
            //transform.localScale = new Vector3(transform.localScale.x / 1.1f, transform.localScale.y / 1.1f, 0f);
        }
    }
}
// -- 9¿ù -- 
// 