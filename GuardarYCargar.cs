using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarYCargar : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();

        GenerarIngresos.esencia = PlayerPrefs.GetFloat("Esencia", 0);
        GenerarIngresos.NivelMachete = PlayerPrefs.GetInt("Machete", 0);
        GenerarIngresos.NivelPala = PlayerPrefs.GetInt("Pala", 0);

        for (int i = 0; i < 3; i++)
        {
            GenerarIngresos.AnimalesActivados[i] = Convert.ToBoolean(PlayerPrefs.GetInt("Activados" + i, 0));
        }

        GenerarIngresos.AumentoPiramide = PlayerPrefs.GetFloat("Aumento", 0);
        GenerarIngresos.multiplicadorPiramide = PlayerPrefs.GetFloat("Multiplicador", 1);

        GenerarIngresos.CantidadRecursos[0] = PlayerPrefs.GetInt("Mangos", 0);
        GenerarIngresos.CantidadRecursos[1] = PlayerPrefs.GetInt("Bichos", 0);

        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                GenerarIngresos.Codices[i, j] = Convert.ToBoolean(PlayerPrefs.GetInt("Codice" + i + j, 0));
            }
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("Esencia", GenerarIngresos.esencia);
        PlayerPrefs.SetInt("Machete", GenerarIngresos.NivelMachete);
        PlayerPrefs.SetInt("Pala", GenerarIngresos.NivelPala);

        for(int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt("Activados" + i, Convert.ToInt32(GenerarIngresos.AnimalesActivados[i]));
        }

        PlayerPrefs.SetFloat("Aumento", GenerarIngresos.AumentoPiramide);
        PlayerPrefs.SetFloat("Multiplicador", GenerarIngresos.multiplicadorPiramide);

        PlayerPrefs.SetInt("Mangos", GenerarIngresos.CantidadRecursos[0]);
        PlayerPrefs.SetInt("Bichos", GenerarIngresos.CantidadRecursos[1]);

        for(int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                PlayerPrefs.SetInt("Codice" + i + j, Convert.ToInt32(GenerarIngresos.Codices[i, j]));
            }
        }
    }
}
