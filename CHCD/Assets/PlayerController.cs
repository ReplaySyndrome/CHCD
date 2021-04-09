using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(pos, Vector2.zero);


            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction,Mathf.Infinity);
            if (hit)
            {
                GameObject objectHit = hit.collider.gameObject;

                print(objectHit.name);
            }
            else
            {
                print("검출되지않았습니다.");
            }

        }

    }

    public void TowerButtonClick(GameObject obj)
    {

    }
}
