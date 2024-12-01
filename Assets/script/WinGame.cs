using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{


    

    [SerializeField]int sayý=0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            sayý++;
        }
        isWin();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            sayý--;
        }
    }

    void isWin()
    {
        if (sayý == 2)
        {
            GameManager.Instance.Win();
        }   
    }
}
