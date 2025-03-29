using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool isPaused = false; // Variable pour suivre l'état de pause

    public Player player;

    private void Update()
    {
      
    }

    // Fonction appelée par le bouton Pause
    public void TogglePause()
    {
        isPaused = !isPaused; // Inverse l'état de la pause

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
