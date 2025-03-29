using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TurnManager : MonoBehaviour
{
    private int _turnCounter = 0;
    [SerializeField] private TextMeshProUGUI turnText;
    [SerializeField] private Button nextTurnButton;
    [SerializeField] private Player player;

    public void PassToNextTurn() {
        nextTurnButton.interactable = false;
        Invoke("SkipTurn", 1f);
    }

    private void SkipTurn() {
        _turnCounter++;
        turnText.text = _turnCounter + "/10";
        var level = LevelManager.instance;
        var tileCoord = PickTile();
        Type type = level.CurrentGrid[tileCoord.x, tileCoord.y].GetType();
        if (level.CurrentGrid[tileCoord.x, tileCoord.y].flooded || type == typeof(Water)) {
            level.SpawnDigue(tileCoord);
            return;
        }
        if (type == typeof(Plaine)) {
            var oldTile = level.CurrentGrid[tileCoord.x, tileCoord.y]; 
            level.CurrentGrid[tileCoord.x, tileCoord.y] = new Bassin(tileCoord.x, tileCoord.y);
            LevelManager.instance.SpawnCase(type, oldTile.transform.position);
            Destroy(oldTile.gameObject);
            return;
        }
        if (type == typeof(Forest)) {
            var oldTile = level.CurrentGrid[tileCoord.x, tileCoord.y];
            level.CurrentGrid[tileCoord.x, tileCoord.y] = new Parking(tileCoord.x, tileCoord.y);
            LevelManager.instance.SpawnCase(type, oldTile.transform.position);
            Destroy(oldTile.gameObject);
            return;
        }
        nextTurnButton.interactable = true;
        player.AddWater();
    }

    private Vector2Int PickTile() {
        int x = Random.Range(0, 16);
        int y = Random.Range(0, 16);
        var tile = LevelManager.instance.CurrentGrid[x, y];
        return tile is House or Building ? PickTile() : new(x,y);
    }
}
