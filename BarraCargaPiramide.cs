using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarraCargaPiramide : MonoBehaviour
{
    private Vector3 Posicion;
    public float Tiempo = 0f;

    private bool MenuActivado = false;
    public bool Cargando = false;
    public bool CodexActivado;

    public GameObject CirculoCarga;
    public GameObject PanelHerramientas;
    public GameObject MenuConfig;
    public ControlMenu menu;

    private void Update()
    {

    }
    public void OnMouseDown()
    {
        if (!MenuActivado && !menu.ActivarMenuBase && !menu.ActivarMenuAnimales && !MenuConfig.activeSelf)
        {
            Tiempo = 0f;
            CirculoCarga.SetActive(true);
            Cargando = true;
        }
    }

    private void OnMouseDrag()
    {
        if (Cargando)
        {
            Tiempo += Time.deltaTime;
            CirculoCarga.transform.position = Input.mousePosition;
            if(Tiempo >= 0.6f)
            {
                //PanelHerramientas.SetActive(true);
                menu.ActivarMenuHerramientas = true;
                MenuActivado = true;
                CirculoCarga.SetActive(false);
            }
        }
    }

    private void OnMouseExit()
    {
        CirculoCarga.SetActive(false);
        Cargando = false;
        Tiempo = 0f;
    }
    private void OnMouseUp()
    {
        Cargando = false;
        CirculoCarga.SetActive(false);
        Tiempo = 0f;
    }

    public void CerrarVentana()
    {
        MenuActivado = false;
        //PanelHerramientas.SetActive(false);
    }
}
