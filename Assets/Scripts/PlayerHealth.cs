using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    int startingHealth;
    Text playerHealthText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefsController.GetDifficulty());
        startingHealth = Mathf.RoundToInt(100 / PlayerPrefsController.GetDifficulty());
        playerHealthText = GetComponent<PlayerHealth>().GetComponent<Text>();
        UpdatePlayerHealthDisplay();
    }

    private void UpdatePlayerHealthDisplay()
    {
        playerHealthText.text = startingHealth.ToString();
    }

    public void ReducePlayerHealth(int amount)
    {
        if (startingHealth > 0)
        {
            startingHealth -= amount;
            UpdatePlayerHealthDisplay();
        }
    }

    public int GetPlayerHealth()
    {
        return startingHealth;
    }

}
