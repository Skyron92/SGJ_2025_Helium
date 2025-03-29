using System;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    public static LevelManager instance;

    private void Start() {
        if (instance == null) instance = this;
        else if(instance != this) Destroy(this);
        InitializeLevel();
    }

    [SerializeField, Range(0, 2)] private float step = 0.5f;

    [Header("Cases prefabs")] 
    [SerializeField] private GameObject plainePrefab;
    [SerializeField] private GameObject forestPrefab;
    [SerializeField] private GameObject parkingPrefab;

    private Case[,] _grid = new Case[16, 16] {
        {new Plaine(0,0), new Plaine(0,1),new Plaine(0,2),new Plaine(0,3),new Plaine(0,4),new Plaine(0,5), new Plaine(0,6),new Plaine(0,7),new Plaine(0,8),new Plaine(0,9),new Plaine(0,10),new Plaine(0,11),new Plaine(0,12),new Plaine(0,13),new Plaine(0,14),new Plaine(0,15)},
        {new Plaine(1,0), new Plaine(1,1),new Plaine(1,2),new Plaine(1,3),new Plaine(1,4),new Plaine(1,5), new Plaine(1,6),new Plaine(1,7),new Plaine(1,8),new Plaine(1,9),new Plaine(1,10),new Plaine(1,11),new Plaine(1,12),new Plaine(1,13),new Plaine(1,14),new Plaine(1,15)},
        {new Plaine(2,0), new Plaine(2,1),new Plaine(2,2),new Plaine(2,3),new Plaine(2,4),new Plaine(2,5), new Plaine(2,6),new Plaine(2,7),new Plaine(2,8),new Plaine(2,9),new Plaine(2,10),new Plaine(2,11),new Plaine(2,12),new Plaine(2,13),new Plaine(2,14),new Plaine(2,15)},
        {new Plaine(3,0), new Plaine(3,1),new Plaine(3,2),new Plaine(3,3),new Plaine(3,4),new Plaine(3,5), new Plaine(3,6),new Plaine(3,7),new Plaine(3,8),new Plaine(3,9),new Plaine(3,10),new Plaine(3,11),new Plaine(3,12),new Plaine(3,13),new Plaine(3,14),new Plaine(3,15)},
        {new Plaine(4,0), new Plaine(4,1),new Plaine(4,2),new Plaine(4,3),new Plaine(4,4),new Plaine(4,5), new Plaine(4,6),new Plaine(4,7),new Plaine(4,8),new Plaine(4,9),new Plaine(4,10),new Plaine(4,11),new Plaine(4,12),new Plaine(4,13),new Plaine(4,14),new Plaine(4,15)},
        {new Plaine(5,0), new Plaine(5,1),new Plaine(5,2),new Plaine(5,3),new Plaine(5,4),new Plaine(5,5), new Plaine(5,6),new Plaine(5,7),new Plaine(5,8),new Plaine(5,9),new Plaine(5,10),new Plaine(5,11),new Plaine(5,12),new Plaine(5,13),new Plaine(5,14),new Plaine(5,15)},
        {new Plaine(6,0), new Plaine(6,1),new Plaine(6,2),new Plaine(6,3),new Plaine(6,4),new Plaine(6,5), new Plaine(6,6),new Plaine(6,7),new Plaine(6,8),new Plaine(6,9),new Plaine(6,10),new Plaine(6,11),new Plaine(6,12),new Plaine(6,13),new Plaine(6,14),new Plaine(6,15)},
        {new Plaine(7,0), new Plaine(7,1),new Plaine(7,2),new Plaine(7,3),new Plaine(7,4),new Plaine(7,5), new Plaine(7,6),new Plaine(7,7),new Plaine(7,8),new Plaine(7,9),new Plaine(7,10),new Plaine(7,11),new Plaine(7,12),new Plaine(7,13),new Plaine(7,14),new Plaine(7,15)},
        {new Plaine(8,0), new Plaine(8,1),new Plaine(8,2),new Plaine(8,3),new Plaine(8,4),new Plaine(8,5), new Plaine(8,6),new Plaine(8,7),new Plaine(8,8),new Plaine(8,9),new Plaine(8,10),new Plaine(8,11),new Plaine(8,12),new Plaine(8,13),new Plaine(8,14),new Plaine(8,15)},
        {new Plaine(9,0), new Plaine(9,1),new Plaine(9,2),new Plaine(9,3),new Plaine(9,4),new Plaine(9,5), new Plaine(9,6),new Plaine(9,7),new Plaine(9,8),new Plaine(9,9),new Plaine(9,10),new Plaine(9,11),new Plaine(9,12),new Plaine(9,13),new Plaine(9,14),new Plaine(9,15)},
        {new Plaine(10,0), new Plaine(10,1),new Plaine(10,2),new Plaine(10,3),new Plaine(10,4),new Plaine(10,5), new Plaine(10,6),new Plaine(10,7),new Plaine(10,8),new Plaine(10,9),new Plaine(10,10),new Plaine(10,11),new Plaine(10,12),new Plaine(10,13),new Plaine(10,14),new Plaine(10,15)},
        {new Plaine(11,0), new Plaine(11,1),new Plaine(11,2),new Plaine(11,3),new Plaine(11,4),new Plaine(11,5), new Plaine(11,6),new Plaine(11,7),new Plaine(11,8),new Plaine(11,9),new Plaine(11,10),new Plaine(11,11),new Plaine(11,12),new Plaine(11,13),new Plaine(11,14),new Plaine(11,15)},
        {new Plaine(12,0), new Plaine(12,1),new Plaine(12,2),new Plaine(12,3),new Plaine(12,4),new Plaine(12,5), new Plaine(12,6),new Plaine(12,7),new Plaine(12,8),new Plaine(12,9),new Plaine(12,10),new Plaine(12,11),new Plaine(12,12),new Plaine(12,13),new Plaine(12,14),new Plaine(12,15)},
        {new Plaine(13,0), new Plaine(13,1),new Plaine(13,2),new Plaine(13,3),new Plaine(13,4),new Plaine(13,5), new Plaine(13,6),new Plaine(13,7),new Plaine(13,8),new Plaine(13,9),new Plaine(13,10),new Plaine(13,11),new Plaine(13,12),new Plaine(13,13),new Plaine(13,14),new Plaine(13,15)},
        {new Plaine(14,0), new Plaine(14,1),new Plaine(14,2),new Plaine(14,3),new Plaine(14,4),new Plaine(14,5), new Plaine(14,6),new Plaine(14,7),new Plaine(14,8),new Plaine(14,9),new Plaine(14,10),new Plaine(14,11),new Plaine(14,12),new Plaine(14,13),new Plaine(14,14),new Plaine(14,15)},
        {new Plaine(15,0), new Plaine(15,1),new Plaine(15,2),new Plaine(15,3),new Plaine(15,4),new Plaine(15,5), new Plaine(15,6),new Plaine(15,7),new Plaine(15,8),new Plaine(15,9),new Plaine(15,10),new Plaine(15,11),new Plaine(15,12),new Plaine(15,13),new Plaine(15,14),new Plaine(15,15)},
        
    };

    private void InitializeLevel() {
        for (int i = 0; i < 16; i++) {
            for (int j = 0; j < 16; j++) {
                Vector3 position = new(i + i* step, 0, j + j * step);
                var @case = _grid[i, j];
                Type type = @case.GetType();
                SpawnCase(type, position);
            }
        }
    }

    private void SpawnCase(Type type, Vector3 position) {
        if (type == typeof(Plaine)) Instantiate(plainePrefab, position, Quaternion.identity);
        if (type == typeof(Forest)) Instantiate(forestPrefab, position, Quaternion.identity);
        if (type == typeof(Parking)) Instantiate(parkingPrefab, position, Quaternion.identity);
    }

    public void CheckNeighbors(Vector2Int coordinate) {
        if (coordinate.x > 0) SearchParking(coordinate.x -1, coordinate.y);
        if (coordinate.x < 15) SearchParking(coordinate.x + 1, coordinate.y);
        if (coordinate.y < 15) SearchParking(coordinate.x, coordinate.y + 1);
        if (coordinate.y > 0) SearchParking(coordinate.x, coordinate.y - 1);
    }

    private void SearchParking(int x, int y) {
        var @case = _grid[x, y];
        if (@case is Parking) {
            @case.ApplyEffect();
        }
    }
}