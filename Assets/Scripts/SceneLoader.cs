using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    int currentScene;
    float sceneLoadWaitTime = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
       currentScene =  SceneManager.GetActiveScene().buildIndex;
        if(currentScene == 0)
        {
            StartCoroutine(DelaySceneLoad());
        }
        
    }

    public void LoadNextScene()
    {
       SceneManager.LoadScene(currentScene + 1);
    }

    IEnumerator DelaySceneLoad()
    {
        yield return new WaitForSeconds(sceneLoadWaitTime);
        LoadNextScene();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
