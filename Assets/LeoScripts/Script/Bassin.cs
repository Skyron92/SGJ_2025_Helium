using DG.Tweening;
using UnityEngine;

public class Bassin : Case
{
    public Bassin(int x, int y) : base(x, y) {}
    
    [SerializeField] private JaugeGoutte waterSlider;
    [SerializeField] private GameObject waterCanvas;

    public AudioClip soundClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnEnable() {
        waterCanvas.SetActive(false);
        waterCanvas.transform.localScale = Vector3.zero;
        waterCanvas.transform.DOScale(Vector3.one, 0.5f);
    }
    
    public override void ApplyEffect() {
        waterSlider.shouldDestroy = Wet();
        waterCanvas.SetActive(true);
        waterSlider.SetImage(waterNested, waterGiven);
        audioSource.PlayOneShot(soundClip);
    }
}