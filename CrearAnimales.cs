using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearAnimales : MonoBehaviour
{
    public GameObject Ave;

    private float Temporizador = 0;
    private float TiempoLimite;
    private float TiempoMinimo = 5;
    private float TiempoMaximo = 10;

    // Start is called before the first frame update
    void Start()
    {
        TiempoLimite = Random.Range(TiempoMinimo, TiempoMaximo);
    }

    // Update is called once per frame
    void Update()
    {
        Temporizador += Time.deltaTime;
        if(Temporizador >= TiempoLimite)
        {
            TiempoLimite = Random.Range(TiempoMinimo, TiempoMaximo);
            Temporizador = 0;
            Instantiate(Ave);
        }
    }
}
