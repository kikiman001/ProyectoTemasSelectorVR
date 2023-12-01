using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollisionProjectile : MonoBehaviour
{
    public float damage = 25f;

    void OnTriggerEnter(Collider other)
    {
        // Verifica si la bala colision� con un enemigo
        if (other.CompareTag("Enemy"))
        {
            // Intenta obtener el componente EnemyHealthBar del enemigo
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            // Si se encuentra el componente, aplica el da�o
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Destruye la bala despu�s de impactar
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si la bala sale de los l�mites
        if (other.CompareTag("Fuera"))
        {
            // Realiza acciones espec�ficas cuando la bala sale de los l�mites
            Destroy(gameObject); // Destruye la bala al salir de los l�mites
        }
    }
}
