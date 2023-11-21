using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDevida : MonoBehaviour
{
    public Image barrdeVida;
    public float vidaActual;
    public float vidaMaxima;
    // Update is called once per frame
    void Update()
    {
        barrdeVida.fillAmount = vidaActual / vidaMaxima;
    }
}
