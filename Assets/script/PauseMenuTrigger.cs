using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuTrigger : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager.Instance.isPaused)
            {
                SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
                GameManager.Instance.isPaused = true;
            }
        }
    }
}
