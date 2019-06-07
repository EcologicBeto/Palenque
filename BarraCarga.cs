using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraCarga : MonoBehaviour
{
    public Image Carga;
    public float Tiempo;
    // Start is called before the first frame update
    void Start()
    {
        Tiempo = 0; 
    }

    private void OnEnable()
    {
        Tiempo = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        Tiempo += Time.deltaTime;
        Carga.fillAmount = Tiempo / 0.6f;
    }
}
