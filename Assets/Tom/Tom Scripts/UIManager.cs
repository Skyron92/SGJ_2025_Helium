using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool isPaused = false; // Variable pour suivre l'état de pause

    public Player player;

    public AudioClip soundClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Fonction appelée par le bouton Pause
    public void TogglePause()
    {
        audioSource.PlayOneShot(soundClip);
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
