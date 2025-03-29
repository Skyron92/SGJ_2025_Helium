using UnityEngine;

public class House : Case
{
    [SerializeField] GameObject house, destroyedHousePrefab;
    [SerializeField, Range(0,15)] private int score = 5;
    
    public House(int x, int y) : base(x, y) {}

    public override void ApplyEffect() {
        Wet();
        Instantiate(destroyedHousePrefab, house.transform.position, new Quaternion(180,0,0,0), transform);
        Destroy(house);
    }
}