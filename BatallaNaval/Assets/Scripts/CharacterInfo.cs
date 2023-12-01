using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public void Select()
    {
        // Implementa las acciones cuando el personaje es seleccionado
        Debug.Log("Personaje seleccionado: " + gameObject.name);
        // Puedes cambiar esto según tus necesidades, por ejemplo, cargar un nivel o activar/desactivar personajes.
    }
}
