using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutasyonHealth : MonoBehaviour,IDamageble
{
    [SerializeField] Material material;
    [SerializeField] float newFloatValue;
    private void Awake()
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material; 
        }
        else
        {
            Debug.LogError("Renderer component not found on " + gameObject.name);
        }
        newFloatValue = material.GetFloat("_DirtAmount");
    }

    public void Damage(float DamageAmount)
    {
        if (newFloatValue >= 1)
        {
            newFloatValue = Mathf.Clamp(newFloatValue - DamageAmount, 0, 100);

        }
        else
        {
            newFloatValue = 0;

            GetComponent<BoxCollider2D>().enabled = false;
        }
        material.SetFloat("_DirtAmount", newFloatValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("asd");
            collision.gameObject.GetComponent<PlayerHealt>().Damage(100);
        }
    }


}
