using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1; // Ýlk karakter
    public Transform player2; // Ýkinci karakter
    public float smoothTime = 0.3f; // Kamera hareketi için yumuþaklýk
    public float minZoom = 5f; // Minimum zoom
    public float maxZoom = 15f; // Maksimum zoom
    public float zoomLimiter = 10f; // Zoom hýzý
    public Vector3 offset; // Kameranýn ofseti

    private Vector3 velocity; // Kamera hýzý
    private Camera cam; // Kamera referansý

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        if (player1 == null || player2 == null) return;

        MoveCamera();
        AdjustZoom();
    }

    void MoveCamera()
    {
        // Ýki karakterin ortalama pozisyonunu hesapla
        Vector3 midpoint = (player1.position + player2.position) / 2f;

        // Kamerayý bu pozisyona yumuþakça hareket ettir
        Vector3 newPosition = midpoint + offset;

        // Z eksenini sabitle
        newPosition.z = -10f; // Z deðeri her zaman 10 olacak

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void AdjustZoom()
    {
        // Ýki karakter arasýndaki mesafeyi al
        float distance = Vector3.Distance(player1.position, player2.position);

        // Kameranýn zoom seviyesini mesafeye göre ayarla
        float newZoom = Mathf.Lerp(maxZoom, minZoom, distance / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
    }
}
