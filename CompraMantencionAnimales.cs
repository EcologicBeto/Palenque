using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompraMantencionAnimales : MonoBehaviour
{
    public ControladorPiramide controladorPiramide;


    private int Animales = 4;
    
    public int[] CantidadAnimales = new int[4];
    public int[] RecursoUsado = new int[4];
    public int[] PrecioAnimales = new int[4];
    public int[] MantenerAnimales = new int[4];
    public float[] EsenciaAnimales = new float[4];
    public float[] TiempoMantener = new float[4];
    public float[] TiempoLimite = new float[4];
    public float[] tiempoActual = new float[4];
    public bool[] AnimalesActivos = new bool[4];
    private float[] GenerarEsencia = new float[4];
    public bool[] Carnivoros = new bool[4];
    public string[] Recurso = new string[4];

    public Image[] Desactivado = new Image[4];
    public GameObject[] BotonAnimal = new GameObject[4];
    public Text[] TextoInformacion = new Text[4];
    public Text[] TextoCantidad = new Text[4];
    


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            GenerarEsencia[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < Animales; i++)
        {
            //Tiempo que los animales se quedan
            if (AnimalesActivos[i])
            {
                TiempoMantener[i] += Time.deltaTime;
                GenerarEsencia[i] += Time.deltaTime;
                if (GenerarEsencia[i] >= 1)
                {
                    global::GenerarIngresos.esencia += EsenciaAnimales[i] * CantidadAnimales[i];
                    GenerarEsencia[i] = 0;
                }

                if(TiempoMantener[i] >= TiempoLimite[i])
                {
                    if(MantenerAnimales[i] * CantidadAnimales[i] > GenerarIngresos.CantidadRecursos[RecursoUsado[i]] || CantidadAnimales[i] <= 0)
                    {
                        AnimalesActivos[i] = false;
                        CantidadAnimales[i] = 0;
                        TiempoMantener[i] = 0;
                        GenerarEsencia[i] = 0;
                    }
                    else if(MantenerAnimales[i] * CantidadAnimales[i] <= GenerarIngresos.CantidadRecursos[RecursoUsado[i]])
                    {
                        GenerarIngresos.CantidadRecursos[RecursoUsado[i]] -= MantenerAnimales[i] * CantidadAnimales[i];
                        TiempoMantener[i] = 0;
                        GenerarEsencia[i] = 0;
                    }
                }
            }
            tiempoActual[i] = TiempoLimite[i] - TiempoMantener[i];

            TextoCantidad[i].text = "Cantidad: " + CantidadAnimales[i];
            TextoInformacion[i].text =  "Costo invocacion: " + PrecioAnimales[i] + Recurso[i] +
                                        "\nCosto mantenimiento: " + MantenerAnimales[i] + Recurso[i] +
                                        "\nTiempo restante: " + tiempoActual[i].ToString("n2") + "seg";
            //Desbloquear animales
            //Los precios estan anotados en el documento
            switch (i)
            {
                case 0:
                    if(GenerarIngresos.CantidadRecursos[RecursoUsado[i]] >= 5 || GenerarIngresos.AnimalesActivados[i])
                    {
                        Desactivado[i].color = new Color(255, 255, 255, 0);
                        BotonAnimal[i].SetActive(true);
                        GenerarIngresos.AnimalesActivados[i] = true;
                    }
                    break;

                case 1:
                    if(GenerarIngresos.CantidadRecursos[RecursoUsado[i]] >= 5 || GenerarIngresos.AnimalesActivados[i])
                    {
                        Desactivado[i].color = new Color(255, 255, 255, 0);
                        BotonAnimal[i].SetActive(true);
                        GenerarIngresos.AnimalesActivados[i] = true;
                    }
                    break;

                case 2:
                    if((GenerarIngresos.CantidadRecursos[RecursoUsado[i]] >= 20 && GenerarIngresos.AnimalesActivados[0]) || GenerarIngresos.AnimalesActivados[i])
                    {
                        Desactivado[i].color = new Color(255, 255, 255, 0);
                        BotonAnimal[i].SetActive(true);
                        GenerarIngresos.AnimalesActivados[i] = true;
                    }
                    break;

                case 3:
                    if((CantidadAnimales[1] >= 8 && GenerarIngresos.AnimalesActivados[1]) || GenerarIngresos.AnimalesActivados[i])
                    {
                        Desactivado[i].color = new Color(255, 255, 255, 0);
                        BotonAnimal[i].SetActive(true);
                        GenerarIngresos.AnimalesActivados[i] = true;
                    }
                    break;
            }
        }
    }

    public void RentarAnimal(int Animal)
    {
        if (!Carnivoros[Animal])
        {
            if (GenerarIngresos.CantidadRecursos[RecursoUsado[Animal]] >= PrecioAnimales[Animal])
            {
                GenerarIngresos.CantidadRecursos[RecursoUsado[Animal]] -= PrecioAnimales[Animal];
                CantidadAnimales[Animal]++;
                TiempoMantener[Animal] = 0;
                AnimalesActivos[Animal] = true;

            }
        }else if (Carnivoros[Animal])
        {
            if(CantidadAnimales[RecursoUsado[Animal]] >= PrecioAnimales[Animal])
            {
                CantidadAnimales[RecursoUsado[Animal]] -= PrecioAnimales[Animal];
                CantidadAnimales[Animal]++;
                TiempoMantener[Animal] = 0;
                AnimalesActivos[Animal] = true;
            }
        }
    }

}
