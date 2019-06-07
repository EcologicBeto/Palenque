using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfiguracionMenu : MonoBehaviour
{

    public GameObject MenuConfiguracion;
    public GameObject BotonConfiguracion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarMenu()
    {
        

        if (!MenuConfiguracion.activeSelf) MenuConfiguracion.SetActive(!MenuConfiguracion.activeSelf);
        BotonConfiguracion.SetActive(!BotonConfiguracion.activeSelf);
    }
}
