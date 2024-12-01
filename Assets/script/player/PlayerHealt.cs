using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealt : MonoBehaviour, IDamageble
{
    [SerializeField] private Slider healthSlider; 
    [SerializeField] private float maxHealth = 100f; 
    private float currentHealth; 
    Anim anim;
    public bool isHit;
    private void Awake()
    {
        anim = GetComponent<Anim>();
    }
    void Start()
    {
        currentHealth = maxHealth; 
        UpdateHealthUI(); 
    }

    public void Damage(float DamageAmount)
    {
        DecreaseHealth(DamageAmount);
    }

    private void DecreaseHealth(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth); 
        UpdateHealthUI();
        anim.Hit();
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth / maxHealth; 
    }
    public void hitOn()
    {
        isHit = true;
    }
    public void hitFalse()
    {
        isHit = false;
    }
}
