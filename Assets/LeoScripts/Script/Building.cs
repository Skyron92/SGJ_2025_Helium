using DG.Tweening;
using UnityEngine;

public class Building : Case
{
    [SerializeField] GameObject house, destroyedHousePrefab;
    [SerializeField, Range(0,15)] private int score = 5;
    
    [SerializeField] private JaugeGoutte waterSlider;
    [SerializeField] private GameObject waterCanvas;
    
    public Building(int x, int y) : base(x, y) {}
    
    private void OnEnable() {
        waterCanvas.SetActive(false);
        waterCanvas.transform.localScale = Vector3.zero;
        waterCanvas.transform.DOScale(Vector3.one, 0.5f);
    }

    public override void ApplyEffect() {
        var shouldDestroy = Wet();
        waterSlider.shouldDestroy = shouldDestroy;
        waterCanvas.SetActive(true);
        waterSlider.SetImage(waterNested, WaterGiven);
        if (!shouldDestroy) return;
        Instantiate(destroyedHousePrefab, house.transform.position, Quaternion.identity, transform); 
        Destroy(house);
    }
}