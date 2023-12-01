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

            // Verifica si se encontr� el script
            if (enemyHealth != null)
            {
                // Aplica el da�o al enemigo
                enemyHealth.TakeDamage(damage);
            }

            // Destruye la bala al impactar
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
