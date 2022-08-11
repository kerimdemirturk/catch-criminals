using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ringRotate : MonoBehaviour
{
    [SerializeField] private float turnSpeed;

    void Update()
    {
        //rotate targetRing
        if(GameManager.isGameStarted == true)
        {
           transform.Rotate(0, 5 * turnSpeed * Time.deltaTime, 0);
        }
        
    }
}
