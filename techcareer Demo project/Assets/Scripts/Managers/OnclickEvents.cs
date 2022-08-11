using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class OnclickEvents : MonoBehaviour
{
    public TextMeshProUGUI soundsText;
    public GameObject resumePanel;
    public int currentSceneIndex; //for getting current scene 
    public int NextsceneIndex; //for getting next scene 
    public GameObject gamePanel;

    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void nextScene()
    {
        SceneManager.LoadScene(NextsceneIndex);
    }
    
    public void pause()
    {
        Time.timeScale = 0;
        resumePanel.SetActive(true);
        gamePanel.SetActive(false);
        
    }

    public void resume()
    {
        Time.timeScale = 1;
        resumePanel.SetActive(false);
        gamePanel.SetActive(true);
    }
   
}
