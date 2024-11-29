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
        anim.Play("idle");
    }
}
