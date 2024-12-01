using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
[RequireComponent(typeof(skils), typeof(Anim))]
[RequireComponent(typeof(PlayerAttack),typeof(PlayerHealt))]
public class playercontroller : MonoBehaviour
{
    [SerializeField]
    private float haraketHizi;
    [SerializeField]
    private float ziplamaGucu;
    private SpriteRenderer sRenderer;
    Rigidbody2D rb;
    [SerializeField] float raydistance;
    float yon;
    [SerializeField] bool ciftzıplayabilir;
    bool isjump;
    skils skil;
    Anim anim;
    [SerializeField]string haraket;
    [SerializeField] KeyCode JumpKey,DashKey,Atk1;
    [SerializeField] PlayerAttack plyratck;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sRenderer = GetComponent<SpriteRenderer>();
        skil = GetComponent<skils>();
        anim = GetComponent<Anim>();
        plyratck = GetComponent<PlayerAttack>();
        
    }


    private void Update()
    {
        if (!GetComponent<PlayerHealt>().isHit)
        {
            Attack();
            if (!plyratck.atak)
            {
                if (!skil.isDashing)
                {
                    if (!YerdeMi())
                    {
                        anim.Jump();
                    }
                    else
                    {


                        if (yon == 0)
                        {
                            anim.Idle();
                        }
                        else
                        {
                            anim.Walk();
                        }

                    }
                }

                jump();
                move();
                Playdash();
                Yonkarar((int)Input.GetAxis(haraket));
                yonDegis();
            }
        }
        
    }

    public bool YerdeMi()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raydistance, (1 << LayerMask.NameToLayer("zemin")) | (1 << LayerMask.NameToLayer("Player")));
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    public void Yonkarar(float yon)
    {
        this.yon = yon;
    }
    public void jump()
    {
        
        if (Input.GetKeyDown(JumpKey))
        {
            
            if (ciftzıplayabilir == false)
            {
                if (YerdeMi())
                {
                    Vector2 zıplamaVektor = new Vector2(0, 1) * ziplamaGucu;
                    rb.AddForce(zıplamaVektor);
                    ciftzıplayabilir = true;
                }
            }
            else if (ciftzıplayabilir == true)
            {
                Vector2 zıplamaVektor = new Vector2(0, 1) * ziplamaGucu;
                rb.AddForce(zıplamaVektor);
                ciftzıplayabilir = false;
            }
        }
    }
    void move()
    {
        transform.Translate(yon * haraketHizi * Time.deltaTime, 0, 0);
    }
    void yonDegis()
    {
        if (yon != 0)
        {  
            if (yon > 0)
            {
                sRenderer.flipX = false;
            }
            else if (yon < 0)
            {
                sRenderer.flipX = true;
            }
        }
    }
    void Playdash()
    {
        if (Input.GetKeyDown(DashKey)&&skil.canDash)
        {
            skil.dash(anim);
        }
    }
    void Attack()
    {
        if (Input.GetKeyDown(Atk1)&& !plyratck.atak)
        {
            plyratck.NormalAttack(anim);
        }  
    }
    
}
