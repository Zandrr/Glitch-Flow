using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    StarDisplay starDisplay;

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetMousePosition());
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        Instantiate(defender, worldPos, transform.rotation);
    }

    private Vector2 SnapToGrid(Vector2 pos)
    {
        float newX = Mathf.RoundToInt(pos.x);
        float newY = Mathf.RoundToInt(pos.y);
        var newPos = new Vector2(newX, newY);
        return newPos;

    }

    public void SetDefenderToPlace(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetDefenderCost();

        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }

    private Vector2 GetMousePosition()
    {
        float mousePosX = Input.mousePosition.x;
        float mousePosY = Input.mousePosition.y;
        Vector2 mousePos = new Vector2(mousePosX, mousePosY);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        
        return SnapToGrid(worldPos);
    }

}
