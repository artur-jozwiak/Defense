using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private float forwardInput;
    private float horizontalInput;

    public ParticleSystem shot;
    [SerializeField] float horsePower;
    [SerializeField] float speed;
    [SerializeField] float turnspeed;

    [SerializeField] Rigidbody playerRb;

    [SerializeField] GameObject turret;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject shotPoint;

    [SerializeField] Vector3 com;
  
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();

        playerRb.centerOfMass = com;
    }

    // Update is called once per frame
    void Update()
    {
        TankMovement();

        Shot();
       
    }
    public void TankMovement()
    {
        forwardInput = Input.GetAxis("Vertical");
        playerRb.AddRelativeForce(Vector3.forward * forwardInput * speed * horsePower);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * turnspeed * horizontalInput);
    }
    public void Shot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(shot, shotPoint.transform.position, turret.transform.rotation);
            Instantiate(bulletPrefab, shotPoint.transform.position, shotPoint.transform.rotation);
        }
       
    }
    

}
