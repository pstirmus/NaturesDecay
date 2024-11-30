using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton örneği
    public static GameManager Instance;
    public bool isPaused = false; // Oyunun paused (duraklatılmış) durumu

    // Bu fonksiyon, sahne geçişi esnasında verilerin kaybolmaması için kullanılır
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Bu GameManager objesi sahne değişse bile yok olmayacak
        }
        else
        {
            Destroy(gameObject); // Eğer zaten bir örneği varsa, bu objeyi sil
        }
    }
}
