using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //game state controls
    public static bool gameOver=false;
    public static bool isGameStarted = false;
    public static bool levelCompleted;
    public static bool mute = false;

    //Canvas Panels
    public GameObject startMenuPanel;
    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePanel;
    public GameObject[] powerUps;

    public int currentSceneIndex; //for getting current scene 
    public int NextsceneIndex; //for getting next scene 

    public TextMesh carsCounter;

    void Start()
    {
        Time.timeScale = 1;//for when restarting everyting start;
        gameOver =  false;
        levelCompleted = false;
        isGameStarted = false;
        

    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            isGameStarted = true;
            startMenuPanel.SetActive(false);
            gamePanel.SetActive(true);
           
        }

        if (gameOver == true)
        {
            Time.timeScale = 0;//stop everything.
            gameOverPanel.SetActive(true);
            gamePanel.SetActive(false);
            
        }
        
        if (levelCompleted == true)
        {
          Time.timeScale = 0;//stop everything.
          levelCompletedPanel.SetActive(true);
          gamePanel.SetActive(false);
        }
        if(isGameStarted == true)
        {
            //powerUps Return;
            foreach (GameObject powerUp in powerUps)
            {
                powerUp.transform.Rotate(0, 2, 0);
            }
        }
        
    }
    


}
