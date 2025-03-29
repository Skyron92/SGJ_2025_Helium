using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool isPaused = false; // Variable pour suivre l'état de pause

    public Player player;

    private void Update()
    {
        Debug.Log(player.is_paused);
    }

    // Fonction appelée par le bouton Pause
    public void TogglePause()
    {
        isPaused = !isPaused; // Inverse l'état de la pause

        if (isPaused)
        {
            Debug.Log("Jeu en pause !");
           
            player.is_paused = true;
        }
        else
        {
            
            Debug.Log("Jeu repris !");
            player.is_paused = false;
        }
    }
}
