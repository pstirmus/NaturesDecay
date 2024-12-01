using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]GameObject plyr1,plyr2;
    [SerializeField] GameObject DeadPanel,WinPanel;

    public bool isPaused;

    public static GameManager Instance=null;
    private void Awake()
    {
        Time.timeScale = 1;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (plyr1.GetComponent<PlayerHealt>().currentHealth < 1 || plyr2.GetComponent<PlayerHealt>().currentHealth < 1)
        {
            DeadPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Win()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
