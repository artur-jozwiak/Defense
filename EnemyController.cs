using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 com;
    public float speed;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = com;
        target = GameObject.Find("EnemyTarget");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (target.transform.position - transform.position).normalized;
        rb.AddRelativeForce(lookDirection * speed, ForceMode.Impulse);
    }
}
