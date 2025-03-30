using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField] private int waterCount;
    [SerializeField] private TextMeshProUGUI waterText;
    [SerializeField] private Button turnButton;
    public bool is_paused;

    public void ChangeWater(int amount) {
        waterCount += amount;
        waterCount = Mathf.Clamp(waterCount, 0, 5);
        waterText.text = waterCount.ToString();
    }

    public void SetPause() {
        is_paused = !is_paused;
        turnButton.interactable = !is_paused;
    }

    public void OnPause(InputAction.CallbackContext context) {
        if (context.performed) SetPause();
    }
    
    public void OnClick(InputAction.CallbackContext context) {
        if(waterCount <= 0 || is_paused) return;
        if (context.canceled) {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)) {
                if (hit.transform.gameObject.TryGetComponent(out Case hitCase)) {
                    if (!hitCase.CheckWaterInNeighbors()) return;
                    ChangeWater(-1);
                    hitCase.ApplyEffect();
                }
            }
        }
    }
}