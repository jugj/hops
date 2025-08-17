using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // Referenz zum Spieler
    public Vector3 offset;     // Abstand zwischen Kamera und Spieler
    public float smoothSpeed = 0.125f; // Weichheit der Bewegung

    void LateUpdate()
{
    if (player != null)
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
}
