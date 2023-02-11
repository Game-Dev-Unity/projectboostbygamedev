using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip DeathExplosion;
    [SerializeField] AudioClip Success;

    [SerializeField] ParticleSystem ExplosionParticles;
    [SerializeField] ParticleSystem SuccessParticles;
    float timeLevelLoading = 1f;

    bool isTransitioning = false;


    void OnCollisionEnter(Collision other) {
        if(isTransitioning) return;
        switch(other.gameObject.tag){
            case "Friendly": {
                break;
            }
            case "Finish": {
                StartSuccessSequence();
                break;
            }
            default: {
                StartCrashSequence();
                break;
            }

        }
    }
    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    void StartCrashSequence(){
        StartSequence("crash");
    }
    void StartSuccessSequence(){
        StartSequence("success");
        // isTransitioning = true;
        // audioSource.Stop();
        // GetComponent<Movement>().enabled = false;
        // audioSource.PlayOneShot(Success);
        // Invoke("LoadNextLevel", timeLevelLoading);
    }
    void StartSequence(string type){
        AudioClip audio = null;
        ParticleSystem particles = null;
        string methodName = null;
        if(type == "crash"){
            methodName = "ReloadLevel";
            audio = DeathExplosion;
            particles = ExplosionParticles;
        }
        if(type == "success"){
            methodName = "LoadNextLevel";
            audio = Success;
            particles = SuccessParticles;
        }
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(audio);
        particles.Play();
        Invoke(methodName, timeLevelLoading);
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
