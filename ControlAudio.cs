using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControlAudio : MonoBehaviour
{
    public AudioMixer Musica;
    public AudioMixer Efectos;

    private float VolMusica = 0f;
    private float VolEfectos = 0f;
    public bool MuteMusica, MuteEfectos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (MuteMusica)
        {
            Musica.SetFloat("MusicaVol", -60f);
        }else if (!MuteMusica)
        {
            Musica.SetFloat("MusicaVol", Mathf.Log10(VolMusica) * 20);
        }

        if (MuteEfectos)
        {
            Efectos.SetFloat("EfectosVol", -60f);
        }
        else if (!MuteMusica)
        {
            Efectos.SetFloat("EfectosVol", Mathf.Log10(VolEfectos) * 20);
        }
    }

    public void VolumenMusica(float ValorSlider)
    {
        VolMusica = ValorSlider;
        //Musica.SetFloat("MusicaVol", Mathf.Log10(ValorSlider) * 20);
    }

    public void VolumenEfectos(float ValorSlider)
    {
        VolEfectos = ValorSlider;
        //Efectos.SetFloat("MusicaVol", Mathf.Log10(ValorSlider) * 20);
    }

    public void SilenciarMusica()
    {
        MuteMusica = !MuteMusica;
    }

    public void SilenciaEfectos()
    {
        MuteEfectos = !MuteEfectos;
    }
}
