using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void StartGame(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentSceneIndex + 1;
        SceneManager.LoadScene(nextLevel);
    }
    public void LoadMainMenu(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = (currentSceneIndex + 1)%SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextLevel);
    }
}
