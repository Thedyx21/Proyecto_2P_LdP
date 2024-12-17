using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    // Velocidad de movimiento de la plataforma
    public float speed = 5f;

    void Update()
    {
        // Mover la plataforma hacia la derecha
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
