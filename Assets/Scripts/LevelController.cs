using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
   [SerializeField] GameObject levelCompleteLabel;
    [SerializeField] GameObject levelLostLabel;
    float numAttackers = 0;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        levelCompleteLabel.SetActive(false);
        levelLostLabel.SetActive(false);
        GameTimer gameTimer = FindObjectOfType<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameTimer>().LevelFinished() && numAttackers == 0)
        {
            StartCoroutine(HandleWinCondition());
        }

        if (IsLevelLost())
        {
            LevelLost();
        }
    }

    public void CountAttackers()
    {
        numAttackers++;
    }

    public void DecrementAttackers()
    {
        numAttackers--;
    }

    IEnumerator HandleWinCondition()
    {
        if (!audioSource.isPlaying) { audioSource.PlayOneShot(audioSource.clip); }
        
        levelCompleteLabel.SetActive(true);
        yield return new WaitForSeconds(2f);
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }


    private void LevelLost()
    {
        levelLostLabel.SetActive(true);
        Time.timeScale = 0;
    }

    private bool IsLevelLost()
    {
        return FindObjectOfType<PlayerHealth>().GetPlayerHealth() <= 0;
    }

}