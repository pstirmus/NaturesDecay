using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool atak;
    [SerializeField] Transform attackPoint;

    [SerializeField]float attackRange = 0.5f;
    float AttakPower = 25f;

    [SerializeField] LayerMask EnemyLayers;
    public void NormalAttack(Anim an)
    {
        an.attack();
    } 
    public void AttakBoolTrue()
    {
        atak = true;
    }
    public void AttakBoolFalse()
    {
        atak = false;
    }
    public void EnemyAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLayers);
        if (hitEnemies != null)
        {
            foreach (Collider2D enemy in hitEnemies)
            {


                if (enemy.gameObject.GetComponent<enemyHealt>() != null)
                {
                    enemy.gameObject.GetComponent<enemyHealt>().Damage(AttakPower);
                }
                if (enemy.gameObject.GetComponent<enemyHealt>() == null)
                {
                    enemy.gameObject.GetComponent<MutasyonHealth>().Damage(AttakPower);
                }

            }
        }
       
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }

}
