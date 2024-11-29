using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
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
    int yon;
    [SerializeField] bool ciftzıplayabilir;
    bool isjump;
    skils skil;
    Anim anim;
    

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sRenderer = GetComponent<SpriteRenderer>();
        skil = GetComponent<skils>();
        anim = GetComponent<Anim>();
        
    }

    
    private void Update()
    {
        move();
        Playdash();
        yonDegis();
        jump();
        
    }
    public bool YerdeMi()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raydistance, 1 << LayerMask.NameToLayer("zemin"));
        if (hit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
    public void Yonkarar(int yon)
    {
        this.yon = yon;
    }
    public void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isjump = true;
            if (ciftzıplayabilir == false)
            {
                if (YerdeMi())
                {
                    Vector2 zıplamaVektor = new Vector2(0, 1) * ziplamaGucu;
                    rb.AddForce(zıplamaVektor);
                    //rb.AddForce(Vector2.up*ziplamaGucu); 
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
        Yonkarar((int)Input.GetAxis("Horizontal1"));
        transform.Translate(yon * haraketHizi * Time.deltaTime, 0, 0);
    }
    void yonDegis()
    {
        if (yon != 0)
        {
            anim.Walk();

            if (yon > 0)
            {
                sRenderer.flipX = false;
            }
            else if (yon < 0)
            {
                sRenderer.flipX = true;
            }

        }
        else
        {
            anim.Idle();
        }
    }
    void Playdash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            skil.dash();
        }
    }
}
