using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    //Player Variables
    [SerializeField] private float playerSpeed;
    [SerializeField] private float xSpeed;
    [SerializeField] private float strifeSpeed;
    private bool isRunning = true;
    private bool isTakePowerUp = false;
    private bool isMakeCelebrations = false;

    //heart system
    private int hitCount;
    public int numberOfHearth;
    public GameObject[] hearts;
   
    //Transforms
    public Transform AIcar;
    public Transform finishLine;

    //Swipe Mechanics Variables
    private Vector3 swipeStartPos;
    private Vector3 swipeEndPos;
    private float swipeStartTime;
    private float swipeEndTime;
    private float swipeTime;
    public float maxSwipeTime;
    private float swipeDistance;
    public float minSwipeDistance;
   

    //Components
    public Rigidbody playerRb;
    public Animator playeranim;

   


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playeranim = GetComponent<Animator>();
        
        
    }

    private void Update()
    {
        if(transform.position.z > finishLine.transform.position.z)
        {
            playeranim.SetTrigger("celebrate");
            GameManager.levelCompleted = true;
            playerRb.velocity = Vector3.zero;
        }
    }

    void FixedUpdate()
    {
        playerMovement();
        swipeMechanics();
    }
    
    private void playerMovement()
    {
        if(GameManager.isGameStarted == false)
        {
            playeranim.SetBool("IsStart", false);
        }
        else
        {
            playeranim.SetBool("IsStart", true);
        }

        if(GameManager.isGameStarted == true)
        {
            if (isRunning)
            {
                playerRb.velocity = transform.forward * playerSpeed * Time.fixedDeltaTime; 
            }
        }   
    }

    //Swiping
    private void swipeMechanics()
    {
        if (GameManager.isGameStarted == true)
        {

            float playerMoveX = 0f;
            if (Input.GetMouseButtonDown(0))
            {
                swipeStartPos = Input.mousePosition;
                swipeStartTime = Time.time;
            }
            else if (Input.GetMouseButton(0))
            {

                swipeEndPos = Input.mousePosition;
                swipeDistance = (swipeEndPos - swipeStartPos).magnitude;
                swipeTime = Time.time - swipeStartTime;

                if (swipeTime < maxSwipeTime && swipeDistance > minSwipeDistance)
                {
                    Vector2 swipeDistance = swipeEndPos - swipeStartPos;
                    playerMoveX = swipeDistance.x;

                }
            }
            playerMoveX = Mathf.Clamp(playerMoveX, -1f, 1f);
            Vector3 velo = playerRb.velocity;
            velo.x = playerMoveX * strifeSpeed * Time.fixedDeltaTime;
            playerRb.velocity = velo;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "car")
        {
            hitCount += 1;

            if(hitCount == 1)
            {
                hearts[0].SetActive(false);
            }
            else if(hitCount ==2)
            {
                hearts[1].SetActive(false);
            }
            else if(hitCount == 3)
            {
                hearts[2].SetActive(false);
            }
            
            if(hitCount<=2)
            {
                playeranim.SetTrigger("bounce");
            }
            if(hitCount>=3)
            {
                //playeranim.SetTrigger("death");
                GameManager.gameOver = true;
            }
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "powerUp")
        {
            isTakePowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(powerUp());
        }
    }

    //powerUp timer
    IEnumerator powerUp()
    {
        if(isTakePowerUp == true)
        {
            isTakePowerUp = false;
            playerSpeed += 150;
            yield return new WaitForSeconds(5);
        }
    }
    
    

}
