using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    StarDisplay starDisplay;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderParent) { defenderParent = new GameObject(DEFENDER_PARENT_NAME); }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetMousePosition());
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(defender, worldPos, transform.rotation) as Defender;
        newDefender.transform.parent = defenderParent.transform;
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
