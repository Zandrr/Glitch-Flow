using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in seconds")]
    [SerializeField] float levelTime = 10;
    bool levelFinished = false;

    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            StopSpawners();
            levelFinished = true;
        }
    }

    private void StopSpawners()
    {
        foreach (AttackerSpawner spawner in FindObjectsOfType<AttackerSpawner>())
        {
            spawner.StopSpawning();
        }
    }

    public bool LevelFinished()
    {
        return levelFinished;
    }
}
