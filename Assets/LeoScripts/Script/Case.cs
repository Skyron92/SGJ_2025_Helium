using UnityEngine;

public abstract class Case : MonoBehaviour
{
    public Vector2Int position;
    [SerializeField] private GameObject waterPrefab;
    [SerializeField, Range(1,5)] protected int waterNested = 1;
    private int _waterGiven;
    
    public abstract void ApplyEffect();

    /// <summary>
    /// Increment the water level of the case
    /// </summary>
    /// <returns>True if the case should be flooded</returns>
    protected bool Wet() {
        _waterGiven++;
        return _waterGiven >= waterNested;
    }
    
    protected void Flood() {
        Instantiate(waterPrefab, transform.position + Vector3.down, Quaternion.identity);
    }
}