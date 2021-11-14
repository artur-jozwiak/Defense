using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private GameObject player;
    public ParticleSystem hit;
    [SerializeField] Rigidbody bulletRb;
    [SerializeField] float bulletSpeed = 1000;
    private float range = 200;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
      
    }

    // Update is called once per frame
    void Update()
    {
        AddForce();
        DestroyOutOfBounds();
    }
    public void AddForce()
    {
        bulletRb.AddRelativeForce(Vector3.up * bulletSpeed);
    }
    public void OnTriggerEnter(Collider other)
    {
        Instantiate(hit, transform.position, hit.transform.rotation);
        Destroy(gameObject); 
    }
    public void DestroyOutOfBounds()
    {
        float posX = transform.position.x;
        float posY = transform.position.y;
        float posZ = transform.position.z;

        float playerPosX = player.transform.position.x;
        float playerPosY = player.transform.position.y;
        float playerPosZ = player.transform.position.z;

        if(posX > range +playerPosX || posY > range + playerPosY || posZ > range + playerPosZ)
        {
            Destroy(gameObject);
        }
        else if (posX <  playerPosX -range || posY <  playerPosY - range || posZ <  playerPosZ- range)
        {
            Destroy(gameObject);
        }
    }
}
