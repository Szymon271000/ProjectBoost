using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("You are safe");
                break;
            case "Finish":
                Debug.Log("You completed the level");
                break;
            case "Obstacle":
                Debug.Log("You bunched an obstacle");
                break;
            case "Fuel":
                Debug.Log("You bunched the fuel");
                break;
            default:
                ReloadLevel();
                //SceneManager.LoadScene("SampleScene");
                break;
             
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        
    }
}
