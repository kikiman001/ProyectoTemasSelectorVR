using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void FacilBtn()
    {
        SceneManager.LoadScene("Facil");
    }

    public void MedioBtn()
    {
        SceneManager.LoadScene("Medio");
    }
    public void DificilBtn()
    {
        SceneManager.LoadScene("Dificil");
    }
    public void SelectorBtn()
    {
        SceneManager.LoadScene("Selector");
    }

}
