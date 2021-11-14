using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelControler : MonoBehaviour
{
    [SerializeField] float barrelMoveSpeed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        BarrelVerticalControl(); 
    }

    public void BarrelVerticalControl()
    {
        float verticalInput = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.left * Time.deltaTime * verticalInput * barrelMoveSpeed);
    }
   
}
