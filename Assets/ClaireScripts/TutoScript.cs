using UnityEngine;

public class TutoScript : MonoBehaviour
{
    public GameObject[] widgets; // Assignez vos 4 widgets dans l'inspecteur
    private int currentWidgetIndex = 0;
    private bool isActive = true;
    [SerializeField] private Player player;

    void Start() {
        player.is_paused = true;
        ShowWidget(currentWidgetIndex);
    }

    void Update() {
        if (isActive && Input.GetMouseButtonDown(0)) // Si clic gauche
        {
            NextWidget();
        }
    }

    void ShowWidget(int index) {
        // D�sactiver tous les widgets
        foreach (GameObject widget in widgets) {
            widget.SetActive(false);
        }

        // Activer le widget actuel si l'index est valide
        if (index < widgets.Length) {
            widgets[index].SetActive(true);
        }
    }

    void NextWidget() {
        currentWidgetIndex++;
        if (currentWidgetIndex < widgets.Length) {
            ShowWidget(currentWidgetIndex);
        }
        else {
            foreach (GameObject widget in widgets) {
                widget.SetActive(false);
            }
            player.is_paused = false;
            Destroy(gameObject); // D�sactiver le script
        }
    }
}