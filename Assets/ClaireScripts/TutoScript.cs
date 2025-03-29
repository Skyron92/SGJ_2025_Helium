using UnityEngine;

public class TutoScript : MonoBehaviour
{
    public GameObject[] widgets; // Assignez vos 4 widgets dans l'inspecteur
    private int currentWidgetIndex = 0;
    private bool isActive = true;

    void Start()
    {
        ShowWidget(currentWidgetIndex);
    }

    void Update()
    {
        if (isActive && Input.GetMouseButtonDown(0)) // Si clic gauche
        {
            NextWidget();
        }
    }

    void ShowWidget(int index)
    {
        // Désactiver tous les widgets
        foreach (GameObject widget in widgets)
        {
            widget.SetActive(false);
        }

        // Activer le widget actuel si l'index est valide
        if (index < widgets.Length)
        {
            widgets[index].SetActive(true);
        }
    }

    void NextWidget()
    {
        currentWidgetIndex++;
        if (currentWidgetIndex < widgets.Length)
        {
            ShowWidget(currentWidgetIndex);
        }
        else
        {
            foreach (GameObject widget in widgets)
            {
                widget.SetActive(false);
            }
            isActive = false; // Désactiver le script
        }
    }
}
