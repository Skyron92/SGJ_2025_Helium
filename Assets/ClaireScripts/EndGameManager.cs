using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnSuivant()
    {
        SceneManager.LoadScene(2);
    }

    public void BtnQuitter()
    {
        Application.Quit();
    }
}
