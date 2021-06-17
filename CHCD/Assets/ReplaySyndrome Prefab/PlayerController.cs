
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngineInternal;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    private GameManager gameManager;
    GameObject seletedTower;
    public Texture2D originalCursorImage = null;
    bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(720, 1080, true);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);

        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();


    
    }

    // Update is called once per frame
    void Update()
    {
        MouseAction();
        Screen.SetResolution(1920, 1080, true);
    }

    

    public void TowerButtonClick(GameObject obj)
    {
        seletedTower = obj;

        //Vector2 cursorpos = new Vector2(originalCursorImage.width / 2, originalCursorImage.width);

        //Cursor.SetCursor(buttonImage.sprite.texture, cursorpos, CursorMode.ForceSoftware);
        isSelected = true;
        //Texture2D towerimage = seletedTower.GetComponent<SpriteRenderer>().sprite.texture;
        
        //Cursor.SetCursor(towerimage, Vector2.zero, CursorMode.ForceSoftware);

    }


    void MouseAction()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(pos, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)            
            {
                if (hit.collider.gameObject.GetComponent<ScreenRayHitter>() && isSelected)
                {
                    GameObject objectHit = hit.collider.gameObject;
                    Instantiate(seletedTower, objectHit.transform.position,Quaternion.Euler(Vector3.zero));                                       
                    isSelected = false;
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                    //Cursor.SetCursor(originalCursorImage, cursorpos, CursorMode.ForceSoftware);
                }

                if(hit.collider.gameObject.GetComponent<StageStartButton>() != null)
                {
                    print("StartBitton");
                }
            }

            
        }

        
        
    }
}
