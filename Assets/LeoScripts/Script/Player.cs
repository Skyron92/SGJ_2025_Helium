using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] private int waterCount;
    [SerializeField] private TextMeshProUGUI waterText;
    public bool is_paused;

    public void AddWater() {
        waterCount += 3;
        waterCount = Mathf.Clamp(waterCount, 0, 5);
        waterText.text = waterCount.ToString();
    }

    public void OnClick(InputAction.CallbackContext context) {
        if(waterCount <= 0) return;
        if (context.canceled) {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)) {
                if (hit.transform.gameObject.TryGetComponent(out Case hitCase)) {
                    if (!hitCase.CheckWaterInNeighbors()) return;
                    waterCount--;
                    waterText.text = waterCount.ToString();
                    hitCase.ApplyEffect();
                }
            }
        }
    }
}