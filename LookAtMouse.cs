using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] Transform turret;
    [SerializeField] Transform barrel;
    public float degresePerSecond;
    public RaycastHit hitInfo;

    
    

    private void Update()
    {
       
       
       Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);// Ray from camera to mouse position(ORGINALNY)
      

        

       // RaycastHit hitInfo;

        if (Physics.Raycast(rayOrigin, out hitInfo))
        {

            if (hitInfo.collider != null)
            {
                Vector3 barrelDirection = hitInfo.point - barrel.position;
                Quaternion lookRotX = Quaternion.LookRotation(barrelDirection);
                barrel.rotation = Quaternion.RotateTowards(barrel.rotation, lookRotX, degresePerSecond * Time.deltaTime);

                Vector3 turretdirection = hitInfo.point - turret.position;
                Quaternion lookRotY = Quaternion.LookRotation(turretdirection);
                turret.rotation = Quaternion.RotateTowards(turret.rotation, lookRotY, degresePerSecond * Time.deltaTime);

              

                Debug.DrawLine(rayOrigin.direction,hitInfo.point, Color.red);
            

           }

        }
     
    }
   
}
