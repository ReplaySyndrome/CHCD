using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_move : MonoBehaviour
{
    bool rot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.gameObject.transform.rotation.eulerAngles.z);

        if (this.gameObject.transform.rotation.eulerAngles.z > 15.0f || this.gameObject.transform.rotation.eulerAngles.z < 0.0f)
            rot = !rot;

        if(rot)
            this.gameObject.transform.Rotate(0, 0, 0.02f);
        else
            this.gameObject.transform.Rotate(0, 0, -0.02f);
    }
}
