using UnityEngine;

public class Cam : MonoBehaviour
{
    public float speed1 = 0.75f; // Vitesse du d�placement
    public float speed2 = 0.5f; // Vitesse du d�placement

    void Update()
    {
        transform.position += Vector3.right * speed1 * Time.deltaTime;
        transform.position += Vector3.forward * speed2 * Time.deltaTime;
    }
}
