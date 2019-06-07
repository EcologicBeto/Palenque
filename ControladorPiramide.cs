using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorPiramide : MonoBehaviour
{

    public int precioPala = 400;
    private string PrecioMachete;

    private int precioMangos = 20;
    private int precioBichos = 20;

    public GameObject[] Maleza;
    public GameObject[] Tierra;

    public Text TextoNivelPala;
    public Text TextoCostosPala;
    public Text TextoNivelMachete;
    public Text TextoCostosMachete;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextoNivelMachete.text = "Nivel: " + global::GenerarIngresos.NivelMachete;
        TextoNivelPala.text = "Nivel: " + global::GenerarIngresos.NivelPala;



        TextoCostosMachete.text = PrecioMachete;
        TextoCostosPala.text = "Costo \nEsencia: " + precioPala * (GenerarIngresos.NivelPala + 1) +
        "\nMangos: " + precioMangos * (GenerarIngresos.NivelPala + 1) +
        "\nBichos: " + precioBichos * (GenerarIngresos.NivelPala + 1);

        for (int i = 0; i < Tierra.Length; i++)
        {
            if(i < GenerarIngresos.NivelPala)
            {
                Tierra[i].SetActive(false);
            }
        }

        for (int i = 0; i < Maleza.Length; i++)
        {
            if (i < GenerarIngresos.NivelMachete)
            {
                Maleza[i].SetActive(false);
            }
        }

        switch (global::GenerarIngresos.NivelMachete)
        {
            case 0:
                PrecioMachete = "Costo \nEsencia: 20\nMangos: 1\nBichos: 1";
                break;

            case 1:
                PrecioMachete = "Costo \nEsencia: 80\nMangos: 4\nBichos: 4";
                global::GenerarIngresos.Codices[0, 0] = true;
                break;

            case 2:
                PrecioMachete = "Costo \nEsencia: 160\nMangos: 8\nBichos: 8";
                global::GenerarIngresos.Codices[0, 1] = true;
                break;

            case 3:
                PrecioMachete = "Costo \nEsencia: 400\nMangos: 20\nBichos: 20";
                global::GenerarIngresos.Codices[0, 2] = true;
                break;

            case 4:
                PrecioMachete = "Costo \nEsencia: 800\nMangos: 40\nBichos: 40";
                global::GenerarIngresos.Codices[1, 0] = true;
                break;

            case 5:
                PrecioMachete = "Nivel Maximo";
                GenerarIngresos.Codices[1, 1] = true;
                break;
        }

        switch (GenerarIngresos.NivelPala)
        {
            case 1:
                GenerarIngresos.Codices[1, 2] = true;
                break;

            case 2:
                global::GenerarIngresos.Codices[2, 0] = true;
                break;

            case 3:
                global::GenerarIngresos.Codices[2, 1] = true;
                break;

            case 4:
                global::GenerarIngresos.Codices[2, 2] = true;
                break;

            case 5:
                global::GenerarIngresos.Codices[3, 0] = true;
                break;

            case 6:
                global::GenerarIngresos.Codices[3, 1] = true;
                break;

            case 7:
                global::GenerarIngresos.Codices[3, 2] = true;
                break;

            case 8:
                global::GenerarIngresos.Codices[4, 0] = true;
                break;

            case 9:
                global::GenerarIngresos.Codices[4, 1] = true;
                break;
        }
    }

    public void SubirNivelMachete()
    {
        switch (global::GenerarIngresos.NivelMachete)
        {
            case 0:
                if(GenerarIngresos.CantidadRecursos[0] >= 1 && GenerarIngresos.CantidadRecursos[1] >= 1 && global::GenerarIngresos.esencia >= 20)
                {
                    GenerarIngresos.CantidadRecursos[0] -= 1;
                    GenerarIngresos.CantidadRecursos[1] -= 1;
                    global::GenerarIngresos.esencia -= 20;

                    global::GenerarIngresos.NivelMachete++;
                    global::GenerarIngresos.AumentoPiramide += 1f;
                    Maleza[global::GenerarIngresos.NivelMachete - 1].SetActive(false);
                }
                break;

            case 1:
                if (GenerarIngresos.CantidadRecursos[0] >= 4 && GenerarIngresos.CantidadRecursos[1] >= 4 && global::GenerarIngresos.esencia >= 80)
                {
                    GenerarIngresos.CantidadRecursos[0] -= 4;
                    GenerarIngresos.CantidadRecursos[1] -= 4;
                    global::GenerarIngresos.esencia -= 80;

                    global::GenerarIngresos.NivelMachete++;
                    global::GenerarIngresos.AumentoPiramide += 1f;
                    Maleza[global::GenerarIngresos.NivelMachete - 1].SetActive(false);
                }
                break;

            case 2:
                if (GenerarIngresos.CantidadRecursos[0] >= 8 && GenerarIngresos.CantidadRecursos[1] >= 8 && global::GenerarIngresos.esencia >= 160)
                {
                    GenerarIngresos.CantidadRecursos[0] -= 8;
                    GenerarIngresos.CantidadRecursos[1] -= 8;
                    global::GenerarIngresos.esencia -= 160;

                    global::GenerarIngresos.NivelMachete++;
                    global::GenerarIngresos.AumentoPiramide += 1f;
                    Maleza[global::GenerarIngresos.NivelMachete - 1].SetActive(false);
                }
                break;

            case 3:
                if (GenerarIngresos.CantidadRecursos[0] >= 20 && GenerarIngresos.CantidadRecursos[1] >= 20 && global::GenerarIngresos.esencia >= 400)
                {
                    GenerarIngresos.CantidadRecursos[0] -= 20;
                    GenerarIngresos.CantidadRecursos[1] -= 20;
                    global::GenerarIngresos.esencia -= 400;

                    global::GenerarIngresos.NivelMachete++;
                    global::GenerarIngresos.AumentoPiramide += 1f;
                    Maleza[global::GenerarIngresos.NivelMachete - 1].SetActive(false);
                }
                break;

            case 4:
                if (GenerarIngresos.CantidadRecursos[0] >= 40 && GenerarIngresos.CantidadRecursos[1] >= 40 && global::GenerarIngresos.esencia >= 800)
                {
                    GenerarIngresos.CantidadRecursos[0] -= 40;
                    GenerarIngresos.CantidadRecursos[1] -= 40;
                    global::GenerarIngresos.esencia -= 800;

                    global::GenerarIngresos.NivelMachete++;
                    global::GenerarIngresos.AumentoPiramide += 1f;
                    Maleza[global::GenerarIngresos.NivelMachete - 1].SetActive(false);
                }
                break;
        }

        /*
        if (GenerarIngresos.esencia >= precioMachete && GenerarIngresos.NivelMachete < Maleza.Length)
        {
            GenerarIngresos.esencia -= precioMachete;
            precioMachete *= 2;

            GenerarIngresos.NivelMachete++;
            GenerarIngresos.AumentoPiramide += 1f;
            Maleza[GenerarIngresos.NivelMachete - 1].SetActive(false);
        }*/

    }

    public void SubirNivelPala()
    {
        if (GenerarIngresos.esencia >= precioPala * (GenerarIngresos.NivelPala + 1) &&
            GenerarIngresos.CantidadRecursos[0] >= precioMangos * (GenerarIngresos.NivelPala + 1) &&
            GenerarIngresos.CantidadRecursos[1] >= precioBichos * (GenerarIngresos.NivelPala + 1) && 
            GenerarIngresos.NivelPala < Tierra.Length)
        {

            GenerarIngresos.esencia -= precioPala * (GenerarIngresos.NivelPala + 1);
            GenerarIngresos.CantidadRecursos[0] -= precioMangos * (GenerarIngresos.NivelPala + 1);
            GenerarIngresos.CantidadRecursos[1] -= precioBichos * (GenerarIngresos.NivelPala + 1);

            GenerarIngresos.NivelPala++;

            GenerarIngresos.multiplicadorPiramide += 1f;
            Tierra[GenerarIngresos.NivelPala - 1].SetActive(false);
        }
    }
}
