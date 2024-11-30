using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skils : MonoBehaviour
{
    private Rigidbody2D rb;
    //dash
    [Header("dash")]
    public float dashAmount = 7f;
    public float dashtime = 0.1f;
    public float HorizontalMove = 7f;
    public bool canDash = true;
    public bool isDashing;
    public float dashColdown;
    private SpriteRenderer sRenderer;
    [Header("mutation")]
    
    public Vector3 mainscharactertransform;
    public GameObject maincharacterscale;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        mainscharactertransform = gameObject.transform.position;
        sRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    public void dash()
    {
        StartCoroutine(dashCorot());
    }

    IEnumerator dashCorot()
    {
        Debug.Log("asd");
        canDash = false;
        isDashing = true;
        rb.gravityScale = 0;
        if (!sRenderer.flipX)
        {
            rb.velocity = new Vector2(HorizontalMove * dashAmount, 1f);
        }
        else if (sRenderer.flipX)
        {
            rb.velocity = new Vector2(-50 - -1.3f , 1f);
        }
        yield return new WaitForSeconds(dashtime);
        rb.velocity = new Vector2(0f, 0f);
        rb.gravityScale = 1f;
        isDashing = false;
        yield return new WaitForSeconds(dashColdown);
        canDash = true;
        
    }
 

}
