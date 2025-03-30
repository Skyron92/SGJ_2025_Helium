using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool isPaused = false; // Variable pour suivre l'�tat de pause

    public Player player;

    public AudioClip soundClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Fonction appel�e par le bouton Pause
    public void TogglePause()
    {
        audioSource.PlayOneShot(soundClip);
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
