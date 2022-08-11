using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public List<GameObject> levels;

    public GameObject currentLevel;
    public int currentLevelId;

    public void NextLevel()
    {
        currentLevelId += 1;
        //SceneManager.sceneLoaded(levels[currentLevelId]);
    }

}
