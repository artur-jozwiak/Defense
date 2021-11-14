using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController2 : MonoBehaviour
{
    [SerializeField] Transform turret;
    [SerializeField] Transform barrel;
    public float degresePerSecond;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        Ray ray = new Ray(origin, direction);
        RaycastHit hitInfo;
        Debug.DrawRay(origin, direction *30, Color.red);

        bool result = Physics.Raycast(ray, out hitInfo);

        if(result)
        {
            Vector3 barrelDirection = hitInfo.point - barrel.position;
            Quaternion lookRotX = Quaternion.LookRotation(barrelDirection);
            barrel.rotation = Quaternion.RotateTowards(barrel.rotation, lookRotX, degresePerSecond * Time.deltaTime);

            Vector3 turretdirection = hitInfo.point - turret.position;
            Quaternion lookRotY = Quaternion.LookRotation(turretdirection);
            turret.rotation = Quaternion.RotateTowards(turret.rotation, lookRotY, degresePerSecond * Time.deltaTime);

        }


    }
}
