using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(PolygonCollider2D))]
[RequireComponent(typeof(skils), typeof(Anim))]
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
    [SerializeField] KeyCode JumpKey,DashKey;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sRenderer = GetComponent<SpriteRenderer>();
        skil = GetComponent<skils>();
        anim = GetComponent<Anim>();
        
    }


    private void Update()
    {
        jump();
        move();
        Playdash();
        Yonkarar((int)Input.GetAxis(haraket));
        yonDegis(); // Her zaman yön değişikliğine izin ver

        if (!YerdeMi())
        {
            anim.Jump();
        }
        else
        {
            if (yon == 0) // Hareket etmiyorsa
            {
                anim.Idle();
            }
            else
            {
                anim.Walk();
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
        if (Input.GetKeyDown(DashKey))
        {
            skil.dash();
        }
    }
    
    
}
