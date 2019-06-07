using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecerPaneles : MonoBehaviour
{
    public CanvasGroup canvas;
    public float VelocidadAlpha;

    private bool ActivarMenu;
    // Start is called before the first frame update
    void Awake()
    {
        canvas = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ActivarMenu)
        {
            canvas.alpha += Time.deltaTime * VelocidadAlpha;
        }else if (!ActivarMenu)
        {
            canvas.alpha -= Time.deltaTime * VelocidadAlpha;
        }

        if(canvas.alpha <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        ActivarMenu = true;
        canvas.alpha = 0.1f;
    }

    public void DesactivarMenu()
    {
        ActivarMenu = false;
    }
}
