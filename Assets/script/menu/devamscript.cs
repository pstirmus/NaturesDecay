using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class devamscript : MonoBehaviour
{
     public void ResumeGame()
    {
        SceneManager.UnloadSceneAsync("PauseMenu"); 
        GameManager.Instance.isPaused = false;
        Time.timeScale = 1f; 
    }
}
