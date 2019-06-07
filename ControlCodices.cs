using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ImagenesCodices
{
    public GameObject[] ImagenCodices;
}

public class ControlCodices : MonoBehaviour
{
    public ImagenesCodices[] imagenesCodices;
    public GameObject[] BotonesCodices;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if (GenerarIngresos.Codices[i, j])
                {
                    imagenesCodices[i].ImagenCodices[j].SetActive(true);
                    imagenesCodices[i].ImagenCodices[j + 3].SetActive(false);
                }
            }

            if (GenerarIngresos.Codices[i, 0] && GenerarIngresos.Codices[i, 1] && GenerarIngresos.Codices[i, 2])
            {
                BotonesCodices[i].SetActive(true);
            }
        }
    }
}
