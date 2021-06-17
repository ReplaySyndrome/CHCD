using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GOGAME : MonoBehaviour
{
    // Start is called before the first frame update
    public void go1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void go2()
    {
        SceneManager.LoadScene("Stage2");
    }
}
