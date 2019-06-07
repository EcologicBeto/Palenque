using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAnimales : MonoBehaviour
{
    [SerializeField]
    private Transform[] Rutas;

    private int SiguienteRuta;

    private float tParam;

    private Vector2 PosicionAnimal;

    private float ModificadorVelocidad;

    private bool PermitirCorrutina;

    // Start is called before the first frame update
    void Start()
    {
        SiguienteRuta = 0;
        tParam = 0;
        ModificadorVelocidad = 0.5f;
        PermitirCorrutina = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PermitirCorrutina)
        {
            StartCoroutine(SeguirLaRuta(SiguienteRuta));
        }
    }

    private IEnumerator SeguirLaRuta(int NumeroRuta)
    {
        PermitirCorrutina = false;

        Vector2 P0 = Rutas[NumeroRuta].GetChild(0).position;
        Vector2 P1 = Rutas[NumeroRuta].GetChild(1).position;
        Vector2 P2 = Rutas[NumeroRuta].GetChild(2).position;
        Vector2 P3 = Rutas[NumeroRuta].GetChild(3).position;

        while(tParam < 1)
        {
            tParam += Time.deltaTime * ModificadorVelocidad;

            PosicionAnimal = Mathf.Pow(1 - tParam, 3) * P0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * P1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * P2 +
                Mathf.Pow(tParam, 3) * P3;

            transform.position = PosicionAnimal;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0;

        SiguienteRuta += 1;
        if (SiguienteRuta > Rutas.Length - 1)
        {
            SiguienteRuta = 0;
        }

        PermitirCorrutina = true;
    }
}
