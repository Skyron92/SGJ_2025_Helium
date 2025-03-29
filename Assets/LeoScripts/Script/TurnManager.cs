using UnityEngine;

public class TurnManager : MonoBehaviour
{

    public void SkipTurn() {
        
    }
    
    public void Build(GameObject gameObject, Vector2Int coords) {
        var spawnPosition = LevelManager.instance.CurrentGrid[coords.x, coords.y].transform.position + Vector3.up;
        Instantiate(gameObject, spawnPosition, Quaternion.identity);
    }
}
