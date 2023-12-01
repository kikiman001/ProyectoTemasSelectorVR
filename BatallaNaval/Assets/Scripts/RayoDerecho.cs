using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayoDerecho : MonoBehaviour
{
    public LayerMask characterLayer;
    public float raycastDistance = 100f;
    public LineRenderer lineRenderer;
    public Transform ControllerTransform; // Asigna el Transform del controlador derecho desde el Inspector

    void Update()
    {
        // Obt�n los valores de los gatillos izquierdo y derecho
        
        float rightTriggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);

        // Si alguno de los gatillos est� presionado hasta cierto umbral, realiza la selecci�n
        if ( rightTriggerValue > 0.5f)
        {
            // Obt�n la posici�n y direcci�n del controlador derecho
            Vector3 controllerPosition = ControllerTransform.position;
            Vector3 controllerDirection = ControllerTransform.forward;

            // Disparar un rayo desde el controlador en la direcci�n hacia adelante
            Ray ray = new Ray(controllerPosition, controllerDirection);

            // Realizar el raycast
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, raycastDistance, characterLayer))
            {
                // Verificar si el objeto impactado tiene un componente de personaje
                CharacterInfo characterInfo = hit.collider.GetComponent<CharacterInfo>();
                if (characterInfo != null)
                {
                    // Seleccionar el personaje (puedes cambiar esto seg�n tus necesidades)
                    characterInfo.Select();
                }

                // Visualizar el rayo con el LineRenderer
                VisualizeRay(controllerPosition, hit.point);
            }
            else
            {
                // Si no hay impacto, visualizar el rayo hasta la distancia m�xima
                VisualizeRay(controllerPosition, controllerPosition + controllerDirection * raycastDistance);
            }
        }
        else
        {
            // Si no hay presi�n en los gatillos, desactivar el LineRenderer
            lineRenderer.enabled = false;
        }
    }

    void VisualizeRay(Vector3 start, Vector3 end)
    {
        // Visualizar el rayo con el LineRenderer
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
}
