﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour {

    public enum Level {
        Level1,
        Level2,
    }
    
    public Level level;
    [SerializeField, Range(5000, 999999)] private int scoreGoalLevel1 = 80000;
    [SerializeField, Range(5000, 999999)] private int scoreGoalLevel2 = 200000;
    
    public static LevelManager instance;

    private void Start() {
        if (instance == null) instance = this;
        else if(instance != this) Destroy(this);
        InitializeLevel();
    }

    public int GetScoreGoal() {
        return level == Level.Level1 ? scoreGoalLevel1 : scoreGoalLevel2;
    }

    [SerializeField, Range(0, 2)] private float step = 0.2f;

    [Header("Cases prefabs")] 
    [SerializeField] private List<GameObject> plainePrefab;
    [SerializeField] private List<GameObject> forestPrefab;
    [SerializeField] private GameObject parkingPrefab;
    [SerializeField] private GameObject bassinPrefab;
    [SerializeField] private GameObject housePrefab;
    [SerializeField] private List<GameObject> buildingPrefabs;
    [SerializeField] private GameObject waterPrefab;
    [SerializeField] private GameObject diguePrefab;

    public Case[,] CurrentGrid {
        get {
            switch (level) {
                case Level.Level1: return _gridLevel1;
                case Level.Level2: return _gridLevel2;
                default: return null;
            }
        }
    }

    private Case[,] _gridLevel1 = new Case[16, 16] {
        {new Forest(0,0), new Forest(0,1),new Forest(0,2),new Forest(0,3),new Water(0,4),new Forest(0,5), new Forest(0,6),new Forest(0,7),new Forest(0,8),new Forest(0,9),new Forest(0,10),new House(0,11),new Forest(0,12),new Forest(0,13),new Forest(0,14),new Forest(0,15)},
        {new Forest(1,0), new Forest(1,1),new Forest(1,2),new Forest(1,3),new Water(1,4),new Water(1,5), new Forest(1,6),new Forest(1,7),new Forest(1,8),new House(1,9),new Plaine(1,10),new Plaine(1,11),new Plaine(1,12),new Plaine(1,13),new House(1,14),new Forest(1,15)},
        {new Forest(2,0), new Forest(2,1),new Plaine(2,2),new House(2,3),new Plaine(2,4),new Water(2,5), new Forest(2,6),new Forest(2,7),new House(2,8),new Plaine(2,9),new Forest(2,10),new Plaine(2,11),new House(2,12),new Plaine(2,13),new Forest(2,14),new Forest(2,15)},
        {new Forest(3,0), new Forest(3,1),new House(3,2),new Plaine(3,3),new Forest(3,4),new Water(3,5), new Water(3,6),new Water(3,7),new Forest(3,8),new Plaine(3,9),new Plaine(3,10),new Forest(3,11),new House(3,12),new Plaine(3,13),new Plaine(3,14),new Forest(3,15)},
        {new Forest(4,0), new Plaine(4,1),new Plaine(4,2),new Parking(4,3),new Plaine(4,4),new Forest(4,5), new Forest(4,6),new Water(4,7),new Water(4,8),new Forest(4,9),new Plaine(4,10),new Plaine(4,11),new House(4,12),new Plaine(4,13),new Plaine(4,14),new Forest(4,15)},
        {new Forest(5,0), new Plaine(5,1),new House(5,2),new Forest(5,3),new Plaine(5,4),new House(5,5), new Forest(5,6),new Plaine(5,7),new Water(5,8),new Plaine(5,9),new Plaine(5,10),new Forest(5,11),new Plaine(5,12),new Plaine(5,13),new Forest(5,14),new Forest(5,15)},
        {new Plaine(6,0), new House(6,1),new Plaine(6,2),new Forest(6,3),new Plaine(6,4),new Plaine(6,5), new Plaine(6,6),new Plaine(6,7),new Water(6,8),new House(6,9),new Forest(6,10),new Plaine(6,11),new Plaine(6,12),new Plaine(6,13),new Forest(6,14),new Forest(6,15)},
        {new Plaine(7,0), new Plaine(7,1),new Building(7,2),new Plaine(7,3),new Forest(7,4),new Forest(7,5), new Plaine(7,6),new Forest(7,7),new Water(7,8),new Water(7,9),new Water(7,10),new Plaine(7,11),new House(7,12),new Plaine(7,13),new Plaine(7,14),new Forest(7,15)},
        {new Plaine(8,0), new Plaine(8,1),new Building(8,2),new Building(8,3),new Plaine(8,4),new Forest(8,5), new Plaine(8,6),new Plaine(8,7),new Forest(8,8),new Forest(8,9),new Water(8,10),new Forest(8,11),new Plaine(8,12),new Plaine(8,13),new House(8,14),new Forest(8,15)},
        {new Plaine(9,0), new Building(9,1),new Parking(9,2),new Building(9,3),new Plaine(9,4),new Parking(9,5), new Plaine(9,6),new Forest(9,7),new Plaine(9,8),new Forest(9,9),new Water(9,10),new Forest(9,11),new Plaine(9,12),new House(9,13),new Plaine(9,14),new Forest(9,15)},
        {new Plaine(10,0), new Plaine(10,1),new Building(10,2),new Building(10,3),new Building(10,4),new Plaine(10,5), new Plaine(10,6),new Forest(10,7),new House(10,8),new Forest(10,9),new Water(10,10),new Water(10,11),new Plaine(10,12),new Plaine(10,13),new Plaine(10,14),new Forest(10,15)},
        {new Plaine(11,0), new Plaine(11,1),new Building(11,2),new Building(11,3),new Parking(11,4),new Building(11,5), new Plaine(11,6),new Plaine(11,7),new Plaine(11,8),new Plaine(11,9),new Plaine(11,10),new Water(11,11),new Forest(11,12),new Forest(11,13),new House(11,14),new Forest(11,15)},
        {new Plaine(12,0), new Building(12,1),new Parking(12,2),new Building(12,3),new Building(12,4),new Plaine(12,5), new Plaine(12,6),new Plaine(12,7),new Plaine(12,8),new Plaine(12,9),new Forest(12,10),new Water(12,11),new Water(12,12),new Water(12,13),new Forest(12,14),new Forest(12,15)},
        {new Forest(13,0), new Plaine(13,1),new Plaine(13,2),new Building(13,3),new Building(13,4),new Parking(13,5), new Building(13,6),new Forest(13,7),new Plaine(13,8),new Plaine(13,9),new Plaine(13,10),new House(13,11),new Forest(13,12),new Water(13,13),new Forest(13,14),new Forest(13,15)},
        {new Forest(14,0), new Forest(14,1),new Plaine(14,2),new Forest(14,3),new Building(14,4),new Building(14,5), new Forest(14,6),new Forest(14,7),new Plaine(14,8),new House(14,9),new Plaine(14,10),new Plaine(14,11),new House(14,12),new Water(14,13),new Water(14,14),new Forest(14,15)},
        {new Forest(15,0), new Forest(15,1),new Forest(15,2),new Forest(15,3),new Forest(15,4),new Forest(15,5), new Forest(15,6),new Forest(15,7),new Plaine(15,8),new Forest(15,9),new Forest(15,10),new Forest(15,11),new Forest(15,12),new Forest(15,13),new Water(15,14),new Forest(15,15)},
    };
    
    private Case[,] _gridLevel2 = new Case[16, 16] {
        {new Forest(0,0), new Water(0,1),new Forest(0,2),new Forest(0,3),new Forest(0,4),new Plaine(0,5), new Plaine(0,6),new Plaine(0,7),new Building(0,8),new Building(0,9),new Building(0,10),new Building(0,11),new Building(0,12),new Plaine(0,13),new Plaine(0,14),new Plaine(0,15)},
        {new Forest(1,0), new Water(1,1),new Plaine(1,2),new Plaine(1,3),new Plaine(1,4),new Forest(1,5), new Plaine(1,6),new House(1,7),new Building(1,8),new Building(1,9),new Building(1,10),new Building(1,11),new Plaine(1,12),new Forest(1,13),new Plaine(1,14),new House(1,15)},
        {new Forest(2,0), new Water(2,1),new Water(2,2),new Plaine(2,3),new Plaine(2,4),new Plaine(2,5), new House(2,6),new Plaine(2,7),new Plaine(2,8),new Plaine(2,9),new Building(2,10),new Building(2,11),new Plaine(2,12),new Forest(2,13),new House(2,14),new Plaine(2,15)},
        {new Forest(3,0), new Forest(3,1),new Water(3,2),new Plaine(3,3),new House(3,4),new Plaine(3,5), new House(3,6),new Plaine(3,7),new Plaine(3,8),new House(3,9),new Plaine(3,10),new Plaine(3,11),new Plaine(3,12),new Plaine(3,13),new Plaine(3,14),new Plaine(3,15)},
        {new Forest(4,0), new Water(4,1),new Water(4,2),new Plaine(4,3),new Plaine(4,4),new Plaine(4,5), new Plaine(4,6),new House(4,7),new Plaine(4,8),new Plaine(4,9),new Plaine(4,10),new Forest(4,11),new Plaine(4,12),new House(4,13),new Plaine(4,14),new Plaine(4,15)},
        {new Forest(5,0), new Water(5,1),new Forest(5,2),new Plaine(5,3),new Plaine(5,4),new Forest(5,5), new Forest(5,6),new Forest(5,7),new Forest(5,8),new Plaine(5,9),new House(5,10),new Forest(5,11),new Plaine(5,12),new Forest(5,13),new Forest(5,14),new Plaine(5,15)},
        {new Water(6,0), new Water(6,1),new Forest(6,2),new House(6,3),new Forest(6,4),new Forest(6,5), new Plaine(6,6),new Plaine(6,7),new Forest(6,8),new Forest(6,9),new Plaine(6,10),new Building(6,11),new Building(6,12),new Parking(6,13),new Building(6,14),new House(6,15)},
        {new Water(7,0), new Forest(7,1),new Forest(7,2),new Plaine(7,3),new Plaine(7,4),new Plaine(7,5), new House(7,6),new Plaine(7,7),new Plaine(7,8),new Forest(7,9),new Plaine(7,10),new Plaine(7,11),new Building(7,12),new Building(7,13),new Building(7,14),new Building(7,15)},
        {new Water(8,0), new Forest(8,1),new Forest(8,2),new Forest(8,3),new Forest(8,4),new Plaine(8,5), new Forest(8,6),new Forest(8,7),new Forest(8,8),new Plaine(8,9),new Plaine(8,10),new House(8,11),new Building(8,12),new Building(8,13),new Building(8,14),new Building(8,15)},
        {new Water(9,0), new Water(9,1),new Forest(9,2),new Forest(9,3),new Forest(9,4),new House(9,5), new Plaine(9,6),new Forest(9,7),new Plaine(9,8),new House(9,9),new Plaine(9,10),new Plaine(9,11),new Building(9,12),new Building(9,13),new Building(9,14),new Building(9,15)},
        {new Forest(10,0), new Water(10,1),new Forest(10,2),new Plaine(10,3),new Forest(10,4),new Plaine(10,5), new Plaine(10,6),new Forest(10,7),new Plaine(10,8),new Plaine(10,9),new Plaine(10,10),new Building(10,11),new Parking(10,12),new Building(10,13),new Building(10,14),new Building(10,15)},
        {new Forest(11,0), new Water(11,1),new Plaine(11,2),new Plaine(11,3),new Plaine(11,4),new Plaine(11,5), new Forest(11,6),new Forest(11,7),new Plaine(11,8),new Forest(11,9),new Plaine(11,10),new Building(11,11),new Building(11,12),new Building(11,13),new Parking(11,14),new Building(11,15)},
        {new Water(12,0), new Water(12,1),new Forest(12,2),new Forest(12,3),new Forest(12,4),new Plaine(12,5), new Forest(12,6),new Forest(12,7),new House(12,8),new Plaine(12,9),new Plaine(12,10),new Building(12,11),new Building(12,12),new Building(12,13),new Building(12,14),new Building(12,15)},
        {new Water(13,0), new Plaine(13,1),new Plaine(13,2),new Plaine(13,3),new Plaine(13,4),new Plaine(13,5), new Plaine(13,6),new Plaine(13,7),new Forest(13,8),new Plaine(13,9),new Forest(13,10),new Plaine(13,11),new Building(13,12),new Parking(13,13),new Building(13,14),new Building(13,15)},
        {new Water(14,0), new Water(14,1),new Forest(14,2),new Plaine(14,3),new Plaine(14,4),new Forest(14,5), new Forest(14,6),new Plaine(14,7),new Plaine(14,8),new Plaine(14,9),new Parking(14,10),new Plaine(14,11),new Building(14,12),new Building(14,13),new Building(14,14),new Building(14,15)},
        {new Forest(15,0), new Water(15,1),new Forest(15,2),new Plaine(15,3),new House(15,4),new Plaine(15,5), new Plaine(15,6),new Plaine(15,7),new Forest(15,8),new Forest(15,9),new Building(15,10),new Building(15,11),new Building(15,12),new Building(15,13),new Forest(15,14),new Forest(15,15)},
    };
    

    private void InitializeLevel() {
        for (int i = 0; i < 16; i++) {
            for (int j = 0; j < 16; j++) {
                Vector3 position = new(i + i* step, 0, j + j * step);
                var @case = CurrentGrid[i, j];
                Type type = @case.GetType();
                var go = SpawnCase(type, position + Vector3.down);
                InsertSpawnedCase(go, i, j);
            }
        }
    }

    public void InsertSpawnedCase(GameObject go, int x, int y) {
        if (go != null) {
            var spawnedCase = go.GetComponent<Case>();
            if(spawnedCase == null) return;
            spawnedCase.position = new(x,y);
            CurrentGrid[x, y] = spawnedCase;
        }
    }

    public GameObject SpawnCase(Type type, Vector3 position) {
        if (type == typeof(Plaine)) return Instantiate(plainePrefab[Random.Range(0,plainePrefab.Count-1)], position, Quaternion.identity);
        if (type == typeof(Forest)) return Instantiate(forestPrefab[Random.Range(0,forestPrefab.Count-1)], position, Quaternion.identity);
        if (type == typeof(Parking)) return Instantiate(parkingPrefab, position, Quaternion.identity);
        if (type == typeof(Bassin)) return Instantiate(bassinPrefab, position, Quaternion.identity);
        if (type == typeof(Digue)) return Instantiate(diguePrefab, position, Quaternion.identity);
        if (type == typeof(House)) return Instantiate(housePrefab, position, Quaternion.identity);
        if (type == typeof(Building)) return Instantiate(buildingPrefabs[Random.Range(0,buildingPrefabs.Count-1)], position, Quaternion.identity);
        if (type == typeof(Water)) return Instantiate(waterPrefab, position, Quaternion.identity);
        return null;
    }

    public void SpawnDigue(Vector2Int coord) {
        void SpawnDigue(Vector3 offset) {
            Instantiate(diguePrefab, CurrentGrid[coord.x, coord.y].transform.position + offset, Quaternion.identity);
        }
        if (!IsWater(coord.x + 1, coord.y)) SpawnDigue(new Vector3(1,1,0));
        if (!IsWater(coord.x - 1, coord.y)) SpawnDigue(new Vector3(-1,1,0));
        if (!IsWater(coord.x, coord.y + 1)) SpawnDigue(new Vector3(0,1,1));
        if (!IsWater(coord.x, coord.y - 1)) SpawnDigue(new Vector3(0,1,-1));
    }

    public bool IsWater(int x, int y) => CurrentGrid[x, y].flooded || CurrentGrid[x,y] is Water;
    public bool IsWater(Vector2Int pos) => CurrentGrid[pos.x, pos.y].flooded || CurrentGrid[pos.x,pos.y] is Water;

    public void CheckParkingInNeighbors(Vector2Int coordinate) {
        if (coordinate.x > 0) SearchParking(coordinate.x -1, coordinate.y);
        if (coordinate.x < 15) SearchParking(coordinate.x + 1, coordinate.y);
        if (coordinate.y < 15) SearchParking(coordinate.x, coordinate.y + 1);
        if (coordinate.y > 0) SearchParking(coordinate.x, coordinate.y - 1);
    }
    public bool CheckWaterInNeighbors(Vector2Int coordinate) {
        return coordinate.x > 0 && IsWater(coordinate.x -1, coordinate.y) ||
        coordinate.x < 15 && IsWater(coordinate.x + 1, coordinate.y) ||
        coordinate.y < 15 && IsWater(coordinate.x, coordinate.y + 1) ||
        coordinate.y > 0 && IsWater(coordinate.x, coordinate.y - 1);
    }

    public void BreakDigue(Vector2Int coord) {
        StartCoroutine(FloodNeighbors(coord, 2));
    }

    IEnumerator FloodNeighbors(Vector2Int coord, int wave) {
        List<Case> neighbors = new List<Case>();
        if(coord.x > 0 && IsWater(coord + Vector2Int.right)) neighbors.Add(CurrentGrid[coord.x + 1, coord.y]);
        if(coord.x < 15 && IsWater(coord + Vector2Int.left)) neighbors.Add(CurrentGrid[coord.x - 1, coord.y]);
        if(coord.y > 0 && IsWater(coord + Vector2Int.up)) neighbors.Add(CurrentGrid[coord.x, coord.y + 1]);
        if(coord.y < 15 && IsWater(coord + Vector2Int.down)) neighbors.Add(CurrentGrid[coord.x, coord.y - 1]);
        foreach (var @case in neighbors) {
            @case.waterGiven = @case.waterNested;
            @case.ApplyEffect();
        }
        wave--;
        if(wave <= 0) yield break;
        yield return new WaitForSeconds(0.5f);
        foreach (var @case in neighbors) {
            StartCoroutine(FloodNeighbors(@case.position, wave));
        }
    }

    private void SearchParking(int x, int y) {
        var @case = CurrentGrid[x, y];
        if (@case is Parking) {
            @case.ApplyEffect();
        }
    }
}