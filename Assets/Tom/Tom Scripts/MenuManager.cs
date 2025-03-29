using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject OptionsUI;
    public GameObject Menu;
    public GameObject Credits;

    public void Load_Level_1()
    {
        SceneManager.LoadScene(1);
    }
    public void Open_Options()
    {
        OptionsUI.SetActive(true);
        Menu.SetActive(false);
        
    }

    public void Quit_Options()
    {
        OptionsUI.SetActive(false);
        Menu.SetActive(true);
    }

    public void Open_Credits()
    {
        Credits.SetActive(true);
        Menu.SetActive(false);
    }

    public void Quit_Credits()
    {
        Credits.SetActive(false);
        Menu.SetActive(true);
    }

    public void Quit_Game()
    {
        Application.Quit();
    }
}
