using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ControlMenu : MonoBehaviour
{
    

    public float velocidadMenu;

    private float PosicionBase, PosicionAnimales, PosicionBoton, PosicionHerramientas;
    public bool ActivarMenuBase, ActivarMenuAnimales, ActivarMenuHerramientas;

    public float PosicionFinalMenuBase;
    public float PosicionFinalMenuAnimales;
    public float PosicionFinalBoton;
    public float PosicionFinalHerramientas;
    //public float PosicionfinalBase, PosicionFinalAnimales, PosicionFinalBoton;

    public RectTransform MenuBase, MenuAnimales, BotonMenu, BotonAnimales, MenuHerramientas;

    public GameObject MenuCodices;
    public GameObject BotonConfig;
    public GameObject MenuOpciones;
    

    private void Start()
    {
        DOTween.SetTweensCapacity(2000, 100);
        PosicionBase = MenuBase.position.y;
        PosicionAnimales = MenuAnimales.position.y;
        PosicionBoton = BotonMenu.transform.position.y;
        PosicionHerramientas = MenuHerramientas.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        PosicionMenu(ActivarMenuBase, MenuBase, PosicionBase, Screen.height/ PosicionFinalMenuBase);
        PosicionMenu(ActivarMenuAnimales, MenuAnimales, PosicionAnimales, Screen.height / PosicionFinalMenuAnimales);


        //Activacion del menu de herramientas
        if (ActivarMenuHerramientas && MenuHerramientas.position.x <= PosicionFinalHerramientas)
        {
            MenuHerramientas.DOMove(new Vector2(Screen.width / PosicionFinalHerramientas, MenuHerramientas.position.y), 1.4f);
            //Menu.position += Vector3.up * Screen.height / velocidadMenu * Time.deltaTime;
        }
        else if (!ActivarMenuHerramientas && MenuHerramientas.position.x >= PosicionHerramientas)
        {
            MenuHerramientas.DOMove(new Vector2(PosicionHerramientas, MenuHerramientas.position.y), 1.4f);
            //Menu.position += Vector3.down * Screen.height / velocidadMenu * Time.deltaTime;
        }

        
        //Activacion del menu base
        if (!ActivarMenuBase && !ActivarMenuAnimales && BotonMenu.position.y <= PosicionBoton)
        {
            BotonMenu.DOMove(new Vector2(BotonMenu.position.x, PosicionBoton), 1.4f);
            //BotonMenu.position += Vector3.up * Screen.height / velocidadMenu * Time.deltaTime;
        }else if((ActivarMenuBase || ActivarMenuAnimales) && BotonMenu.position.y >= Screen.height / PosicionFinalBoton)
        {
            BotonMenu.DOMove(new Vector2(BotonMenu.position.x, PosicionFinalBoton), 1.4f);
            //BotonMenu.position += Vector3.down * Screen.height / velocidadMenu * Time.deltaTime;
        }
    }

    public void PosicionMenu(bool MenuActivo, Transform Menu, float PosicionMenuInicial, float PosicionMenuFinal)
    {
        if (MenuActivo && Menu.position.y <= PosicionMenuFinal)
        {
            Menu.DOMove(new Vector2(Menu.position.x, PosicionMenuFinal), 1.4f);
            //Menu.position += Vector3.up * Screen.height / velocidadMenu * Time.deltaTime;
        }
        else if (!MenuActivo && Menu.position.y >= PosicionMenuInicial)
        {
            Menu.DOMove(new Vector2(Menu.position.x, PosicionMenuInicial), 1.4f);
            //Menu.position += Vector3.down * Screen.height / velocidadMenu * Time.deltaTime;
        }
    }

    public void MoverMenu(string opcion)
    {
        switch (opcion)
        {
            case "ActivarMenuBase":
                ActivarMenuBase = true;
                ActivarMenuAnimales = false;
                break;

            case "ActivarMenuAnimales":
                ActivarMenuAnimales = true;
                ActivarMenuBase = false;
                break;

            case "ActivarMenuCodex":
                ActivarMenuAnimales = false;
                ActivarMenuBase = false;
                MenuCodices.SetActive(true);
                BotonConfig.SetActive(false);
                MenuOpciones.SetActive(false);
                break;

            case "DesactivarTodo":
                ActivarMenuAnimales = false;
                ActivarMenuBase = false;
                break;

            case "DesactivarCodex":
                //MenuCodices.SetActive(false);
                BotonConfig.SetActive(true);
                break;

            case "DesactivarHerramientas":
                ActivarMenuHerramientas = false;
                break;
        }
    }
}
