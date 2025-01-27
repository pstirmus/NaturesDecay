using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Anim : MonoBehaviour
{
    [SerializeField]Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void Idle()
    {
        anim.Play("idle");

    }
    public void Walk()
    {
        anim.Play("run");
    }
    public void Jump()
    {
        anim.Play("Jump");
    }
    public void attack()
    {
        anim.Play("attak");
    }
    public void Dash()
    {
        anim.Play("Dash");
    }
    public void Hit()
    {
        anim.Play("hit");
    }
}
