using UnityEngine;

public class Cam : MonoBehaviour
{
    public float speed1 = 0.01f; // Vitesse du déplacement
    public float speed2 = 0.05f; // Vitesse du déplacement

    public float minX = 0f; // Position minimum en X
    public float maxX = 1f; // Position maximum en X

    private int direction = 1; // 1 pour avancer, -1 pour reculer

    void Update()
    {
        transform.position += Vector3.right * speed1 * direction * Time.deltaTime;
        transform.position += Vector3.forward * speed2 * direction * Time.deltaTime;

        // Vérifie si la caméra atteint les limites
        if (transform.position.x >= maxX)
        {
            direction = -1; // On inverse la direction (retour arrière)
        }
        else if (transform.position.x <= minX)
        {
            direction = 1; // On repart en avant

        }

        // Vérifie si la caméra atteint les limites
        if (transform.position.z >= maxX)
        {
            direction = -1; // On inverse la direction (retour arrière)
        }
        else if (transform.position.z <= minX)
        {
            direction = 1; // On repart en avant

        }
    }
}
