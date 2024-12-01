using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealt : MonoBehaviour
{
    [SerializeField] float can;
    [SerializeField] Animator anim;
    public bool isHit;
    public void Damage(float DamageAmount)
    {
        if (can > 0)
        {
            can = can - DamageAmount;
            anim.SetTrigger("hit");
        }
        else
        {
            can = 0;
            anim.SetTrigger("hit");
            anim.SetBool("Dead", true);
        }
    }
    void Dead()
    {
        Destroy(gameObject);
    }
    void hitOn()
    {
        isHit = true;
    }
    void HitOf()
    {
        isHit = false;
    }

}
