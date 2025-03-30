using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Slider volumeSlider; // Glisser le slider dans l'inspecteur

    void Start()
    {
        // Charger le volume sauvegard� ou mettre une valeur par d�faut
        float savedVolume = PlayerPrefs.GetFloat("gameVolume", 1f);
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;

        // Ajouter un �couteur d'�v�nement
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume; // Modifier le volume global
        PlayerPrefs.SetFloat("gameVolume", volume); // Sauvegarder la valeur
        PlayerPrefs.Save();
    }
}
