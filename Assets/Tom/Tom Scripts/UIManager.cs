using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool isPaused = false; // Variable pour suivre l'�tat de pause

    public Player player;

    private void Update()
    {
        Debug.Log(player.is_paused);
    }

    // Fonction appel�e par le bouton Pause
    public void TogglePause()
    {
        isPaused = !isPaused; // Inverse l'�tat de la pause

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
