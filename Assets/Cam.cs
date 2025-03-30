using UnityEngine;

public class Cam : MonoBehaviour
{
    public float speed1 = 0.01f; // Vitesse du d�placement
    public float speed2 = 0.05f; // Vitesse du d�placement

    public float minX = 0f; // Position minimum en X
    public float maxX = 1f; // Position maximum en X

    private int direction = 1; // 1 pour avancer, -1 pour reculer

    void Update()
    {
        transform.position += Vector3.right * speed1 * direction * Time.deltaTime;
        transform.position += Vector3.forward * speed2 * direction * Time.deltaTime;

        // V�rifie si la cam�ra atteint les limites
        if (transform.position.x >= maxX)
        {
            direction = -1; // On inverse la direction (retour arri�re)
        }
        else if (transform.position.x <= minX)
        {
            direction = 1; // On repart en avant

        }

        // V�rifie si la cam�ra atteint les limites
        if (transform.position.z >= maxX)
        {
            direction = -1; // On inverse la direction (retour arri�re)
        }
        else if (transform.position.z <= minX)
        {
            direction = 1; // On repart en avant

        }
    }
}
