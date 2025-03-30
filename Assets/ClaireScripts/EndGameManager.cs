using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{

    public void BtnSuivant() {
        SceneManager.LoadScene(2);
    }

    public void BtnQuitter() {
        SceneManager.LoadScene(0);
    }
}
