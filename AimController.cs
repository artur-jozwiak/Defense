using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField] Transform turret;
    [SerializeField] Transform barrel;
    public float degresePerSecond;
    //public RaycastHit hitInfo;

    // Start is called before the first frame update
    private void OnValidate()
    {
        if (camera == null)
            camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mouseScreenPos = Input.mousePosition;
        Ray ray = camera.ScreenPointToRay(mouseScreenPos);

        Debug.DrawRay(ray.origin, ray.direction * 40.0f, Color.red);

        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
           Vector3 barrelDirection = raycastHit.point - barrel.position;
           Quaternion lookRotX = Quaternion.LookRotation(barrelDirection);
           barrel.rotation = Quaternion.RotateTowards(barrel.rotation, lookRotX, degresePerSecond * Time.deltaTime);

            Vector3 turretdirection = raycastHit.point - turret.position;
            Quaternion lookRotY = Quaternion.LookRotation(turretdirection);
            turret.rotation = Quaternion.RotateTowards(turret.rotation, lookRotY, degresePerSecond * Time.deltaTime);

        }
    }
}
