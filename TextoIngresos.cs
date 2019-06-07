using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoIngresos : MonoBehaviour
{
    public CompraMantencionAnimales mantencionAnimales;
    public ComprarRecursos comprar;
    public Text TextoEsencia;
    public Text RecursoMango;
    public Text RecursoHormiga;
    public Text RecursoFlor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextoEsencia.text = ((int)GenerarIngresos.esencia).ToString();
        RecursoMango.text = GenerarIngresos.CantidadRecursos[0].ToString();
        RecursoHormiga.text = GenerarIngresos.CantidadRecursos[1].ToString();
    }
}
