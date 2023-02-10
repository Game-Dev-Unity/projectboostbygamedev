using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    float timeLevelLoading = 1f;
    void OnCollisionEnter(Collision other) {
        switch(other.gameObject.tag){
            case "Friendly": {
                Debug.Log("Do Nothing");
                break;
            }
            case "Obstacle": {
                StartCrashSequence();
                break;
            }
            case "Finish": {
                StartSuccessSequence();
                break;
            }

        }
    }
    void StartCrashSequence(){
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", timeLevelLoading);
    }
    void StartSuccessSequence(){
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", timeLevelLoading);
    }
    void ReloadLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        int nextLevel = (currentSceneIndex+1)%sceneCount;
        SceneManager.LoadScene(nextLevel);
    }
}
