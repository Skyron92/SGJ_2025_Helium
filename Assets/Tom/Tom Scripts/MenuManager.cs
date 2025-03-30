using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{

    public GameObject OptionsUI;
    public GameObject Menu;
    public GameObject Credits;

    public AudioClip soundClip;  
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void Load_Level_1()
    {
        audioSource.PlayOneShot(soundClip);
        SceneManager.LoadScene(1);
    }
    public void Open_Options()
    {
        audioSource.PlayOneShot(soundClip);
        OptionsUI.SetActive(true);
        Menu.SetActive(false);
    }

    public void Quit_Options()
    {
        audioSource.PlayOneShot(soundClip);
        OptionsUI.SetActive(false);
        Menu.SetActive(true);
    }

    public void Open_Credits()
    {
        audioSource.PlayOneShot(soundClip);
        Credits.SetActive(true);
        Menu.SetActive(false);
    }

    public void Quit_Credits()
    {
        audioSource.PlayOneShot(soundClip);
        Credits.SetActive(false);
        Menu.SetActive(true);
    }

    public void Quit_Game()
    {
        audioSource.PlayOneShot(soundClip);
        Application.Quit();
    }
}
