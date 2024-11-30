using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void ExitGameOnClick()
    {
        Debug.Log("Oyundan Çıkılıyor...");
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
