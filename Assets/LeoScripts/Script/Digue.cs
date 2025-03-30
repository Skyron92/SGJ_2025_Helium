using DG.Tweening;
using UnityEngine;

public class Digue : Case {
    
    public Digue(int x, int y) : base(x, y) {}
    
    [SerializeField] private JaugeGoutte waterSlider;
    [SerializeField] private GameObject waterCanvas;

    [SerializeField] private GameObject digue;

    public AudioClip soundClip;
    [SerializeField] private AudioSource audioSource;

    private void OnEnable() {
        waterCanvas.SetActive(false);
        waterCanvas.transform.localScale = Vector3.zero;
        waterCanvas.transform.DOScale(Vector3.one, 0.5f);
        SpawnDigues();
    }

    private void SpawnDigues() {
        var level = LevelManager.instance;
        if(position.x < 15 && level.IsWater(position + Vector2Int.right)) Instantiate(digue, transform.position, Quaternion.identity, transform);
        if(position.x > 0 && level.IsWater(position + Vector2Int.left)) Instantiate(digue, transform.position, new Quaternion(0,180,0,0), transform);
        if(position.y < 15 && level.IsWater(position + Vector2Int.up)) Instantiate(digue, transform.position, new Quaternion(0,90,0,0), transform);
        if(position.y > 0 && level.IsWater(position + Vector2Int.down)) Instantiate(digue, transform.position, new Quaternion(0,-90,0,0), transform);
    }

    public override void ApplyEffect() {
        var shouldDestroy = Wet();
        waterSlider.shouldDestroy = shouldDestroy;
        waterCanvas.SetActive(true);
        waterSlider.SetImage(waterNested, waterGiven);
        if (!shouldDestroy) return;
        LevelManager.instance.BreakDigue(position);
        audioSource.PlayOneShot(soundClip);
        Destroy(gameObject);
    }
}