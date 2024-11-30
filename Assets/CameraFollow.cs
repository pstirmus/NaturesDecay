using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player1; // �lk karakter
    public Transform player2; // �kinci karakter
    public float smoothTime = 0.3f; // Kamera hareketi i�in yumu�akl�k
    public float minZoom = 5f; // Minimum zoom
    public float maxZoom = 15f; // Maksimum zoom
    public float zoomLimiter = 10f; // Zoom h�z�
    public Vector3 offset; // Kameran�n ofseti

    private Vector3 velocity; // Kamera h�z�
    private Camera cam; // Kamera referans�

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
        // �ki karakterin ortalama pozisyonunu hesapla
        Vector3 midpoint = (player1.position + player2.position) / 2f;

        // Kameray� bu pozisyona yumu�ak�a hareket ettir
        Vector3 newPosition = midpoint + offset;

        // Z eksenini sabitle
        newPosition.z = -10f; // Z de�eri her zaman 10 olacak

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void AdjustZoom()
    {
        // �ki karakter aras�ndaki mesafeyi al
        float distance = Vector3.Distance(player1.position, player2.position);

        // Kameran�n zoom seviyesini mesafeye g�re ayarla
        float newZoom = Mathf.Lerp(maxZoom, minZoom, distance / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
    }
}
