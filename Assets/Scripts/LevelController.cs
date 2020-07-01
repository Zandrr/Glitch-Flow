using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
   [SerializeField] GameObject levelCompleteLabel;
    float numAttackers;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        levelCompleteLabel.SetActive(false);
        GameTimer gameTimer = FindObjectOfType<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameTimer>().LevelFinished() && numAttackers == 0)
        {
            Debug.Log("All enemies dead and game time up");
            StartCoroutine(HandleWinCondition());
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

}