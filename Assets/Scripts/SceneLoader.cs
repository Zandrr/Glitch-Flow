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
        Time.timeScale = 1;
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

    public void ReloadCurrentScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene);
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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameOverScene()
    {
        SceneManager.LoadScene("Game Over");
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void OptionsScene()
    {
        SceneManager.LoadScene("Options Screen");
    }

    IEnumerator DelayGameOverScene()
    {
        yield return new WaitForSeconds(sceneLoadWaitTime);
        GameOverScene();
    }

    public void LoadGameOverSceneWithDelay()
    {
        StartCoroutine(DelayGameOverScene());
    }
}
