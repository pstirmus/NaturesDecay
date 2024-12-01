using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZonescrp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player2")
        {
            collision.gameObject.GetComponent<PlayerHealt>().Damage(100);
        }
    }
}
