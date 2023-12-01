using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 20f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Obtiene la referencia al script del enemigo
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            // Verifica si se encontró el script
            if (enemyHealth != null)
            {
                // Aplica el daño al enemigo
                enemyHealth.TakeDamage(damage);
            }

            // Destruye la bala al impactar
            Destroy(gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Verifica si la bala sale de los límites
        if (other.CompareTag("Fuera"))
        {
            // Realiza acciones específicas cuando la bala sale de los límites
            Destroy(gameObject); // Destruye la bala al salir de los límites
        }
    }
}
