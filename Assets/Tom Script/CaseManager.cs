using UnityEngine;



public abstract class CaseManager : MonoBehaviour
{

    GameObject WaterPrefab;


    public abstract void ApplyEffect();
    private void OnMouseEnter()
    {
        
    }

    public Vector2Int Coordinate_pos;
}

