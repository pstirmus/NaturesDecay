using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D),typeof(BoxCollider2D))]
public class playercontroller : MonoBehaviour
{
    [SerializeField]
    private float haraketHizi;
    [SerializeField]
    private float ziplamaGucu;
    private SpriteRenderer sRenderer;
    Rigidbody2D rb;
    /*Animator anim;*/
    int yon;
    bool ciftzıplayabilir;



    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        /*anim = gameObject.GetComponent<Animator>();*/
        sRenderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        transform.Translate(yon * haraketHizi * Time.deltaTime,0,0);
        if (yon!=0)
        {
            /*anim.SetBool("kosuyor", true);*/

            if (yon > 0)
            {
                sRenderer.flipX = false;
            }
            else if (yon < 0)
            {
                sRenderer.flipX = true;
            }

        }
        /*else
        {
            anim.SetBool("kosuyor", false);
        }*/
        Yonkarar((int)Input.GetAxis("Horizontal1"));
    }
    

    public bool YerdeMi()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.6f, 1 << LayerMask.NameToLayer("Zemin"));
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
