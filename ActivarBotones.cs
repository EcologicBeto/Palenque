using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivarBotones : MonoBehaviour
{
    public GameObject Boton;
    public Image Imagen;
    public int Costo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GenerarIngresos.esencia < Costo)
        {
            Boton.SetActive(false);
            Imagen.color = new Color(255, 255, 255, 0.5f);
        }else if(GenerarIngresos.esencia >= Costo)
        {
            Boton.SetActive(true);
            Imagen.color = new Color(255, 255, 255, 0);
        }
    }
}
