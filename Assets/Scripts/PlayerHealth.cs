using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int startingHealth = 100;
    Text playerHealthText;
    // Start is called before the first frame update
    void Start()
    {
        playerHealthText = GetComponent<PlayerHealth>().GetComponent<Text>();
        UpdatePlayerHealthDisplay();
    }

    private void Update()
    {
        if (isGameOver())
        {
            GameOver();
        }
    }

    private void UpdatePlayerHealthDisplay()
    {
        playerHealthText.text = startingHealth.ToString();
    }

    public void ReducePlayerHealth(int amount)
    {
        startingHealth -= amount;
        UpdatePlayerHealthDisplay();
    }

    private void GameOver()
    {

        GetComponent<SceneLoader>().GameOverScene();
    }

    private bool isGameOver()
    {
        return startingHealth <= 0;
    }

}
