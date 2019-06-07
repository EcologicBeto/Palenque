using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class MostrarInfoCodex : MonoBehaviour
{
    public GameObject mostrarInfoPrefab;
    //public GameObject ContenedorBotones;
    public GameObject PantallaObjetos;
    public Transform ContenedorObjetos;


    XmlDocument ObjetosInfoXml;

    private void Awake()
    {
        TextAsset xmltextAsset = Resources.Load<TextAsset>("ArchivosXml/DatosCodex");
        ObjetosInfoXml = new XmlDocument();
        ObjetosInfoXml.LoadXml(xmltextAsset.text);
        PantallaObjetos.SetActive(false);
    }

    public void EncontrarTodosLosObjetos()
    {
        XmlNodeList Objetos = ObjetosInfoXml.SelectNodes("/ObjetosActuales/ObjetoActual");

        foreach(XmlNode Objeto in Objetos)
        {
            CrearInventarioObjetos(Objeto);
        }
        MostrarInventarioObjetos();
    }

    public void EncontrarTipoObjetos(string TipoObjeto)
    {
        XmlNodeList Objetos = ObjetosInfoXml.SelectNodes("/ObjetosActuales/ObjetoActual[@Type='" + TipoObjeto + "'] ");

        foreach(XmlNode Objeto in Objetos)
        {
            CrearInventarioObjetos(Objeto);
        }
        MostrarInventarioObjetos();
    }

    public void EncontrarIDObjetos(string ObjetoID)
    {
        XmlNode Objetos = ObjetosInfoXml.SelectSingleNode("/InformacionesCodex/InformacionCodex[@ID='" + ObjetoID + "']");

        CrearInventarioObjetos(Objetos);
        MostrarInventarioObjetos();
    }

    void CrearInventarioObjetos(XmlNode objeto)
    {
        GameObject ObjetoNuevoUI = GameObject.Instantiate(mostrarInfoPrefab, ContenedorObjetos);

        ObjetoInventario NuevoObjetoInventario = new ObjetoInventario(objeto);
        NuevoObjetoInventario.ActualizarInvetario(ObjetoNuevoUI);
    }

    void MostrarInventarioObjetos()
    {
        //ContenedorBotones.SetActive(false);
        PantallaObjetos.SetActive(true);
    }

    public void BotonRegresar()
    {
        foreach(Transform t in ContenedorObjetos)
        {
            Destroy(t.gameObject);
        }
        PantallaObjetos.SetActive(false);
    }

    class ObjetoInventario
    {
        public string IDObjeto { get; private set;  }
        //public string TipoObjeto { get; private set; }
        public string NombreObjeto { get; private set; }
        public string DescripcionObjeto { get; private set; }
        public Color bgColor { get; private set; }
        public Texture ImagenObjeto { get; private set; }

        public ObjetoInventario(XmlNode NodoObjeto)
        {
            IDObjeto = NodoObjeto.Attributes["ID"].Value;
            //TipoObjeto = NodoObjeto.Attributes["Type"].Value;
            NombreObjeto = NodoObjeto["TituloCodex"].InnerText;
            DescripcionObjeto = NodoObjeto["HistoriaCodex"].InnerText;

            XmlNode NodoColor = NodoObjeto.SelectSingleNode("ColorBG");

            float bgR = float.Parse(NodoColor["r"].InnerText);
            float bgG = float.Parse(NodoColor["g"].InnerText);
            float bgB = float.Parse(NodoColor["b"].InnerText);
            float bgA = float.Parse(NodoColor["a"].InnerText);

            bgR = NormalizarColor(bgR);
            bgG = NormalizarColor(bgG);
            bgB = NormalizarColor(bgB);
            bgA = NormalizarColor(bgA);

            bgColor = new Color(bgR, bgG, bgB, bgA);

            string LocalizacionImagen = "ImagenesCodex/" + NodoObjeto["ImagenCodex"].InnerText;

            ImagenObjeto = Resources.Load<Texture2D>(LocalizacionImagen);
        }

        float NormalizarColor(float valor)
        {
            valor = valor / 255f;
            return valor;
        }

        public void ActualizarInvetario(GameObject UIInventario)
        {
            Transform TransformUIInventario = UIInventario.transform;

            Image ObjetoBGPanel;
            RawImage ObjetoRawImagen;
            Text ObjetoNombre;
            Text ObjetoDescripcion;

            ObjetoBGPanel = TransformUIInventario.GetComponent<Image>();
            Transform ObjetoBGPanelTransform = ObjetoBGPanel.GetComponent<Transform>();
            ObjetoRawImagen = ObjetoBGPanelTransform.Find("ImagenObjeto").GetComponent<RawImage>();
            ObjetoNombre = ObjetoBGPanelTransform.Find("TextoTitulo").GetComponent<Text>();
            ObjetoDescripcion = ObjetoBGPanelTransform.Find("TextoHistoria").GetComponent<Text>();

            ObjetoBGPanel.color = bgColor;
            ObjetoRawImagen.texture = ImagenObjeto;
            ObjetoNombre.text = NombreObjeto;
            ObjetoDescripcion.text = DescripcionObjeto;
        }
    }
}
