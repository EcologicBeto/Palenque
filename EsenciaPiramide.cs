using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EsenciaPiramide : MonoBehaviour
{
    public ControladorPiramide controladorPiramide;
    public float esencia = 1f;
    public float esenciaSegundo = 1f;
    public float TiempoSegundo = 0f;

    public float velocidadNiebla = 1f;
    private Vector3 PosicionInicial = new Vector3(0f, 0f, 3f);

    // Start is called before the first frame update
    void Awake()
    {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TiempoSegundo += Time.deltaTime;
        if (TiempoSegundo >= 1)
        {
            TiempoSegundo = 0;
            GenerarIngresos.esencia += esenciaSegundo + GenerarIngresos.AumentoPiramide;
        }
    }

    private void OnMouseDown()
    {
        GenerarIngresos.esencia += esencia * GenerarIngresos.multiplicadorPiramide;

    }
}
