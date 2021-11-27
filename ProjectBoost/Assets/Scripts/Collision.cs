using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    [SerializeField] float delay = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip succecedSound;
    AudioSource audios;
    bool isTransitioning = false;

    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (isTransitioning == false)
        {
            switch (collision.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("You are safe");
                    break;
                case "Finish":
                    StartNextLevel();
                    break;
                default:
                    StartCrashSequence();
                    //SceneManager.LoadScene("SampleScene");
                    break;
            }
        }
    }

    void StartCrashSequence()
    {
        //TODO add SFX upon crash
        //TODO add particle effects
        isTransitioning = true;
        audios.Stop();
        audios.PlayOneShot(crashSound);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delay);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currentSceneIndex);
    }
    void StartNextLevel()
    {
        isTransitioning = true;
        audios.Stop();
        audios.PlayOneShot(succecedSound);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", delay);
    }
    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) // total number of scenes
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
