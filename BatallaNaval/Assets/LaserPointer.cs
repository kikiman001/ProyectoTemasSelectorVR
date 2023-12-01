using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public float laserDistance = 10f;
    public GameObject cursorPrefab;  // Prefab del cursor

    private LineRenderer lineRenderer;
    private GameObject cursor;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        CreateCursor();
    }

    void Update()
    {
        UpdateLaserPointer();
    }

    void CreateCursor()
    {
        // Instancia el cursor
        cursor = Instantiate(cursorPrefab, Vector3.zero, Quaternion.identity);
        cursor.SetActive(false);  // Desactiva el cursor por defecto
    }

    void UpdateLaserPointer()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, laserDistance))
        {
            // Si el láser golpea algo, ajusta la longitud del láser para llegar al punto de impacto
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);

            // Muestra el cursor y ajusta su posición al punto de impacto
            cursor.SetActive(true);
            cursor.transform.position = hit.point;
        }
        else
        {
            // Si el láser no golpea nada, ajusta la longitud del láser para que alcance la distancia máxima
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * laserDistance);

            // Desactiva el cursor cuando no hay colisión
            cursor.SetActive(false);
        }
    }
}
