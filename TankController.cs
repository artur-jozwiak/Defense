using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Transform[] whellMeshes;
    public WheelCollider[] wheelColliders;

    Vector3 pos;
    Vector3 rotation;//powoduje nie obracanie w osi x
    public Vector3 com;
    Quaternion quat;

    private float forwardInput;
   
    public float rotSpeed;
    public float horsePower;
    private float horizontalInput;

    [SerializeField] float speed;
    [SerializeField] GameObject turret;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject shotPoint;

    public ParticleSystem shot;

    [SerializeField] Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        com = playerRb.centerOfMass;
       rotation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        TankMovement();
        ShotControl();
        
    }
    public void TankMovement()
    {
        transform.eulerAngles = rotation;
        forwardInput = Input.GetAxis("Vertical");
        for (int i = 0; i < wheelColliders.Length; i++)
        {
           wheelColliders[i].GetWorldPose(out pos, out quat);
           whellMeshes[i].position = pos;
          whellMeshes[i].rotation = quat;
        }
        foreach (var whellcolliders in wheelColliders)
        {
            whellcolliders.motorTorque = forwardInput * horsePower * Time.deltaTime;
        }
        playerRb.AddRelativeForce(Vector3.forward * forwardInput * speed * horsePower);

        rotation.y += Input.GetAxis("Horizontal") * rotSpeed;
        // horizontalInput = Input.GetAxis("Horizontal");   //Druga opcja skecania
        //transform.Rotate(Vector3.up * rotSpeed * horizontalInput);

    }
    public void ShotControl()
    {
        if (Input.GetMouseButtonDown(0))
         {
          Instantiate(shot, shotPoint.transform.position, turret.transform.rotation);
          Instantiate(bulletPrefab, shotPoint.transform.position, shotPoint.transform.rotation);
         }
    }
}
