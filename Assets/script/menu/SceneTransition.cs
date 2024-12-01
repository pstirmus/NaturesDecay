using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void OnContinueButtonClicked()  // Bu fonksiyon public olmalı
    {
        Debug.Log("Continue Button Clicked!");  // Bu log'u görmelisiniz
        SceneManager.LoadScene("Level");  // Sahne geçişi
    }
    public void OnContinueButtonClickedHome()  // Bu fonksiyon public olmalı
    {
        Debug.Log("Continue Button Clicked!");  // Bu log'u görmelisiniz
        SceneManager.LoadScene("MainMenu");  // Sahne geçişi
    }
}
