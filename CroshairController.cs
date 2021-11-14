using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CroshairController : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {
       
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if esc key coursor visible = true
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }
        transform.position = Input.mousePosition;
    }
}
