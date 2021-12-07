using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadtest : MonoBehaviour
{
    public userdata_save test;
    public Image test_obj;
    public Image test_obji;
    //public Color test_color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        viewsave();
    }

    public void viewsave()
    {
        //Color test_color = test_obj.color;
        if (test.testb == true)
        {
            test_obj.color = Color.blue;
        }
        else
        {
            test_obj.color = Color.red;
        }

        if (test.testi == 1)
        {
            test_obji.color = Color.yellow;
        }
        else if (test.testi == 2)
        {
            test_obji.color = Color.green;
        }

    }
}
