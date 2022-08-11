using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float carspeed;
    public float forwardPower;
    public Rigidbody carRb;
    public float flySpeed = 10.0f;

    public float explosionForce = 2.0f;
    public float radius = 5.0F;
    public bool isHit = false;
    

    void Start()
    {
        Vector3 expPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(GameManager.isGameStarted == true)
        {
            carRb.velocity = Vector3.forward * Time.deltaTime * carspeed;


            if (isHit == true)
            {
                transform.rotation = Quaternion.Euler(0, 30, 30);
                transform.Translate(Vector3.up * flySpeed * Time.deltaTime);
                carRb.AddForce(Vector3.forward * forwardPower, ForceMode.Impulse);
            }

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="player")
        {
            isHit = true;
            //carRb.AddForce(Vector3.up*flySpeed, ForceMode.Impulse);
        }
    }
    
    
    

}
