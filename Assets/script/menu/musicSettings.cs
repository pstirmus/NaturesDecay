using UnityEngine;

public class musicSettings : MonoBehaviour
{
    // AudioSource bileşeni
    public AudioSource muzikSource;

    // Müzik durdurma fonksiyonu
    public void MüzikKapat()
    {
        if (muzikSource.isPlaying)
        {
            muzikSource.Pause();  // Müzik duraklatılır
        }
    }

    // Müzik başlatma fonksiyonu (isteğe bağlı)
    public void MüzikBaşlat()
    {
        if (!muzikSource.isPlaying)
        {
            muzikSource.Play();  // Müzik başlatılır
        }
    }
}
