using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    // Referencia al Slider de la barra de vida
    public Slider healthSlider;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Implementa acciones cuando la salud llega a cero (puedes destruir el enemigo u otras acciones)
        Destroy(gameObject);
    }

    void UpdateHealthUI()
    {
        // Actualiza el valor de la barra de vida
        Debug.Log("UpdateHealthUI - Current Health: " + currentHealth);
        healthSlider.value = currentHealth;
    }
  

}
