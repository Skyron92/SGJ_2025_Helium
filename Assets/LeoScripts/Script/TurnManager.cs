using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TurnManager : MonoBehaviour
{
    private int _turnCounter = 1;
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
        if (_turnCounter >= 10) {
            Player.instance.Loose();
            return;
        }
        DoAction();
        nextTurnButton.interactable = true;
        player.ChangeWater(3);
    }

    private void DoAction() {
        var level = LevelManager.instance;
        var tileCoord = PickTile();
        Type type = level.CurrentGrid[tileCoord.x, tileCoord.y].GetType();
        if (level.CurrentGrid[tileCoord.x, tileCoord.y].flooded || type == typeof(Water)) {
            var oldTile = level.CurrentGrid[tileCoord.x, tileCoord.y];
            level.CurrentGrid[tileCoord.x, tileCoord.y] = new Digue(tileCoord.x, tileCoord.y);
            var go = level.SpawnCase(typeof(Digue), oldTile.transform.position + Vector3.down);
            level.InsertSpawnedCase(go, tileCoord.x, tileCoord.y);
            Destroy(oldTile.gameObject);
        }
        if (type == typeof(Plaine)) {
            var oldTile = level.CurrentGrid[tileCoord.x, tileCoord.y]; 
            level.CurrentGrid[tileCoord.x, tileCoord.y] = new Bassin(tileCoord.x, tileCoord.y);
            var go = level.SpawnCase(typeof(Bassin), oldTile.transform.position + Vector3.down);
            level.InsertSpawnedCase(go, tileCoord.x, tileCoord.y);
            Destroy(oldTile.gameObject);
        }
        if (type == typeof(Forest)) {
            var oldTile = level.CurrentGrid[tileCoord.x, tileCoord.y];
            level.CurrentGrid[tileCoord.x, tileCoord.y] = new Parking(tileCoord.x, tileCoord.y);
            var go = level.SpawnCase(typeof(Parking), oldTile.transform.position + Vector3.down);
            level.InsertSpawnedCase(go, tileCoord.x, tileCoord.y);
            Destroy(oldTile.gameObject);
        }
    }

    private Vector2Int PickTile() {
        int x = Random.Range(0, 16);
        int y = Random.Range(0, 16);
        var tile = LevelManager.instance.CurrentGrid[x, y];
        return tile is House {flooded:false} or Building {flooded:false} ? PickTile() : new(x,y);
    }
}
