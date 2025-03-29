using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool isPaused = false; // Variable pour suivre l'�tat de pause

    public Player player;

    private void Update()
    {
      
    }

    // Fonction appel�e par le bouton Pause
    public void TogglePause()
    {
        isPaused = !isPaused; // Inverse l'�tat de la pause

        if (isPaused)
        {
            Debug.Log("Jeu en pause !");
           
          
        }
        else
        {
            
            Debug.Log("Jeu repris !");
          
        }
    }
}
