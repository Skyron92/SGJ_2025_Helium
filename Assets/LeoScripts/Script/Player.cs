using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public List<AudioClip> waterSounds;
    public AudioClip clickSound;
    private AudioSource audioSource;

    [SerializeField] private int waterCount;
    [SerializeField] private TextMeshProUGUI waterText;
    [SerializeField] private Button turnButton;
    public bool is_paused;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }


    public void ChangeWater(int amount) {
        waterCount += amount;
        waterCount = Mathf.Clamp(waterCount, 0, 5);
        waterText.text = waterCount.ToString();
        waterText.transform.DOScale(Vector3.one * 1.3f, 0.2f).onComplete += () => 
            waterText.transform.DOScale(Vector3.one, 0.2f);
    }

    public void SetPause() {
        is_paused = !is_paused;
        turnButton.interactable = !is_paused;
    }

    public void OnPause(InputAction.CallbackContext context) {
        if (context.performed) SetPause();
    }
    
    public void OnClick(InputAction.CallbackContext context) {
        if(is_paused) return;
        if (context.canceled) {
            if (waterCount <= 0) {
                var pos = waterText.transform.position;
                waterText.transform.DOShakePosition(0.5f, 3, 10, 0, true).onComplete += () => 
                    waterText.transform.position = pos;
                waterText.DOColor(Color.red, 0.3f).onComplete += () => 
                    waterText.DOColor(Color.white, 0.2f).onComplete += () => 
                        waterText.DOColor(Color.red, 0.3f).onComplete += () => 
                            waterText.DOColor(Color.white, 0.2f) ;
                return;
            }
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)) {
                if (hit.transform.gameObject.TryGetComponent(out Case hitCase)) {
                    if (!hitCase.CheckWaterInNeighbors()) return;
                    audioSource.PlayOneShot(clickSound);
                    ChangeWater(-1);
                    int randomIndex = Random.Range(0, waterSounds.Count);
                    audioSource.PlayOneShot(waterSounds[randomIndex]);
                    hitCase.ApplyEffect();
                }
            }
        }
    }
}