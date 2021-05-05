
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    Image buttonImage;
    public Texture2D originalCursorImage = null;
    bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(720, 1080, true);

    
    }

    // Update is called once per frame
    void Update()
    {
        MouseAction();
        Screen.SetResolution(1920, 1080, true);
    }

    

    public void TowerButtonClick(GameObject obj)
    {
        print("버튼눌려따");
        buttonImage = obj.GetComponent<Image>();

        Vector2 cursorpos = new Vector2(originalCursorImage.width / 2, originalCursorImage.width);

        //Cursor.SetCursor(buttonImage.sprite.texture, cursorpos, CursorMode.ForceSoftware);
        isSelected = true;
    }


    void MouseAction()
    {

        print(isSelected);
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
                    Sprite temp = buttonImage.sprite;
                    
                    objectHit.GetComponent<SpriteRenderer>().sprite = buttonImage.sprite;
                    objectHit.transform.localScale =  new Vector3(5.0f, 5.0f, 1f);
                    print(objectHit.name);
                    isSelected = false;

                    Vector2 cursorpos = new Vector2(buttonImage.sprite.texture.width / 2, buttonImage.sprite.texture.width);


                    //Cursor.SetCursor(originalCursorImage, cursorpos, CursorMode.ForceSoftware);
                }
            }

            else
            {
                print("검출되지않았습니다.");
            }

            
        }

        
        
    }
}
