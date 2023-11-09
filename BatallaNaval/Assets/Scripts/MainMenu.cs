using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void FacilBtn()
    {
        SceneManager.LoadScene("NivelFacil");
    }

    public void MedioBtn()
    {
        SceneManager.LoadScene("NivelMedio");
    }
    public void DificilBtn()
    {
        SceneManager.LoadScene("NivelDificil");
    }
    public void SelectorBtn()
    {
        SceneManager.LoadScene("Selector");
    }

}
