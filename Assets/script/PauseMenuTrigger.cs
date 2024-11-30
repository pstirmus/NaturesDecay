using UnityEngine;

public class PauseMenuTrigger : MonoBehaviour
{
    public GameObject pausePanel;  // Pause Panel'inin referansı
    private bool isPaused = false;  // Oyun duraklatılmış mı kontrolü

    void Update()
    {
        // ESC tuşuna basıldığında pause menüsünü aç/kapat
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // Oyun devam etsin
            }
            else
            {
                PauseGame(); // Oyun duraklatılsın
            }
        }
    }

    // Oyunu duraklat ve pause menüsünü göster
    public void PauseGame()
    {
        pausePanel.SetActive(true); // Pause Panel'ini aktif et
        Time.timeScale = 0f; // Zamanı durdur, oyun donmuş olur
        isPaused = true; // Pause durumuna geçiş
    }

    // Oyunu devam ettir ve pause menüsünü gizle
    public void ResumeGame()
    {
        pausePanel.SetActive(false); // Pause Panel'ini gizle
        Time.timeScale = 1f; // Zamanı normalleştir
        isPaused = false; // Oyun devam ediyor
    }
}
