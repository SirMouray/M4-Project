using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 300;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void UpdateHealthUI()
    {
        Healthbar healthbar = FindObjectOfType<Healthbar>();
        if (healthbar != null)
        {
            healthbar.UpdateHealth(currentHealth, maxHealth);
        }
    }
}

