using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComprarRecursos : MonoBehaviour
{

    public int Recursos = 3;

    public int[] CantidadRecursos = new int[3];
    public int[] PrecioRecursos = new int[3];

    public Image BotonMultiplicador;
    public Sprite[] SpriteMultiplicador;
    private int OpcionMultiplicador;

    public CompraMantencionAnimales animales;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BotonMultiplicador.sprite = SpriteMultiplicador[OpcionMultiplicador];
    }

    public void Comprar(int Recurso)
    {
        switch (OpcionMultiplicador)
        {
            //Multiplicador de 1
            case 0:
                if (GenerarIngresos.esencia >= PrecioRecursos[Recurso])
                {
                    GenerarIngresos.esencia -= PrecioRecursos[Recurso];
                    GenerarIngresos.CantidadRecursos[Recurso]++;
                }
                break;

                //Multiplicador de 5
            case 1:
                if (GenerarIngresos.esencia >= 5 * PrecioRecursos[Recurso])
                {
                    GenerarIngresos.esencia -= 5 * PrecioRecursos[Recurso];
                    GenerarIngresos.CantidadRecursos[Recurso] += 5;
                }
                break;

                //Multiplicador de 10
            case 2:
                if (GenerarIngresos.esencia >= 10 * PrecioRecursos[Recurso])
                {
                    GenerarIngresos.esencia -= 10 * PrecioRecursos[Recurso];
                    GenerarIngresos.CantidadRecursos[Recurso] += 10;
                }
                break;
        }
    }

    public void CambiarMultiplicador()
    {
        OpcionMultiplicador++;
        if(OpcionMultiplicador > 2)
        {
            OpcionMultiplicador = 0;
        }
    }
}
