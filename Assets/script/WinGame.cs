using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{


    

    [SerializeField]int say�=0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            say�++;
        }
        isWin();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            say�--;
        }
    }

    void isWin()
    {
        if (say� == 2)
        {
            GameManager.Instance.Win();
        }   
    }
}
