using UnityEngine;
using UnityEngine.UI;

public class JaugeGoutte : MonoBehaviour
{
    public Image image;
    public float eau;
    public float reserve;

    public void SetImage(float maxvalue, float value)
    {
        image.fillAmount = value / maxvalue;
        Debug.Log(image.fillAmount);
    }

    void Update()
    {
        if (image != null)
        {
            SetImage(reserve, eau);
        }
    }
}
