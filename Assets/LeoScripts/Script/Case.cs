using UnityEngine;

public abstract class Case : MonoBehaviour
{
    public Case(int x, int y) {
        position = new Vector2Int(x, y);
    }
    public Vector2Int position;
    [SerializeField] private GameObject waterPrefab;
    [SerializeField, Range(1,5)] protected int waterNested = 1;
    protected int WaterGiven;

    private void CheckNeighbors() => LevelManager.instance.CheckNeighbors(position);

    public abstract void ApplyEffect();
    
    protected bool Wet() {
        WaterGiven++;
        if (WaterGiven < waterNested) return false;
        Flood();
        Invoke("CheckNeighbors", 0.3f);
        return true;
    }
    
    protected void Flood() {
        Instantiate(waterPrefab, transform.position + Vector3.down, Quaternion.identity);
    }
}