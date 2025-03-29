using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public GameObject OptionsUI;

    public void Load_Level_1()
    {
        SceneManager.LoadScene(1);
    }
    public void Load_Options()
    {
        OptionsUI.SetActive(true);
    }
    public void Quit_Game()
    {
        Application.Quit();
    }
}
