using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Vector2 pos1, pos2;
    [SerializeField] float speed;
    float oldpoz;

    [SerializeField] float Distance, attackDistance;

    [SerializeField]Transform target;

    Animator anim;
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask PlayerLayers;


    [SerializeField] float attackRange = 0.5f;
    float AttakPower = 25f;
    RaycastHit2D HitenemyAtck;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        Physics2D.queriesStartInColliders = false;
    }
    private void Update()
    {
        if (GetComponent<enemyHealt>().isHit==false)
        {
            EnemyAi();
           
        } 
        
    }
    void EnemyMove()
    {
        pos1 = new Vector2(pos1.x, transform.position.y);
        pos2 = new Vector2(pos2.x, transform.position.y);
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
        if (transform.position.x>oldpoz)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (transform.position.x < oldpoz)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        oldpoz = transform.position.x;
    }

    void EnemyAi()
    {
        Vector3 Hitpos = new Vector3(transform.position.x, transform.position.y - 0.69f, transform.position.z);
        RaycastHit2D Hitenemy = Physics2D.Raycast(Hitpos, transform.right, Distance);
       
        
        if (Hitenemy.collider != null&& Hitenemy.collider.gameObject == target.gameObject)
        {
            Vector3 HitposHitenemy = new Vector3(Hitenemy.transform.position.x, transform.position.y - 0.69f, Hitenemy.transform.position.z);
            EnemyFollow();
            Debug.DrawLine(Hitpos, HitposHitenemy, Color.red);
        }
        else
        {
            Debug.DrawLine(Hitpos, transform.position+transform.right*Distance, Color.blue);
            EnemyMove();

        }
    }

    void EnemyFollow()
    {
        Vector2 targetPosition = new Vector2(target.position.x+ 0.7f, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, 1 * Time.deltaTime);

        EnemyAttackAI();
    }
    void EnemyAttackAI()
    {
        Vector3 Hitpos = new Vector3(transform.position.x, transform.position.y - 0.69f, transform.position.z);
        HitenemyAtck = Physics2D.Raycast(Hitpos, transform.right, attackDistance);
        if (HitenemyAtck.collider != null && HitenemyAtck.collider.gameObject == target.gameObject)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }
    public void EnemyAttack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange,PlayerLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<PlayerHealt>().Damage(AttakPower);
        }
    }
}
