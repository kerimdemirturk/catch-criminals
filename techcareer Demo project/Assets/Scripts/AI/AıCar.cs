using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class AıCar : MonoBehaviour
{
    public Rigidbody rb;
    public Transform destination;
    private bool isPlayerTouch = false;
    private int AıcarCounter = 0;
    private int playerTouchCounter = 3;

    public GameObject count3;
    public GameObject count2;
    public GameObject count1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   
    void Update()
    {
        setDestination();
    }

    //give destination to Aı car.
    private void setDestination()
    {
        
        if(GameManager.isGameStarted == true)
        {
            if (destination != null)
            {
                NavMeshAgent Aıcar = GetComponent<NavMeshAgent>();
                Aıcar.destination = destination.transform.position;
            }
        }
    }

    //check trigger events
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            Destroy(gameObject);
            playerTouchCounter -= 1;

            if(playerTouchCounter == 2)
            {
                count3.SetActive(false);
                count2.SetActive(true);
            }

            if(playerTouchCounter == 1)
            {
                count2.SetActive(false);
                count1.SetActive(true);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "finishLine")
        {
            AıcarCounter += 1;
            Debug.Log("crash: "+AıcarCounter);
            //gameOver
            if (AıcarCounter >= 2)
            {
                GameManager.gameOver = true;
                Debug.Log("çalış");
            }
        }
    }
    
}
