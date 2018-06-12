using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Peticion4 : MonoBehaviour
{

    // Use this for initialization
    private Text timer;
    private Text mostrar;
    private Text respuestat;
    private float tiempo;
    private string Xml;
    private XmlDocument xmlDoc;
    private string codigo;
    private Image mito;
    private Image nuc;
    private Image nuco;
    private Image ret;
    private Image cit;
    private Button sig;

    private string Mensaje;

    /*Datos del servidor*/
    private string DireccionIp = "192.168.127.6";
    private string Puerto = "8080";

    /*Codigo Tags de los organelos*/
    private static string Reticulo = "2C00AC411D";
    private string pregunta = "5) ¿Que organelo actua como un sistema de comunicacion interna permitiendo el transporte de sustancias de un lugar a otro?";
    private string respuesta = "2C00AC411D";
    private int aleatorio;

    public AudioSource sourceCorrecto;
    public AudioSource sourceError;
    public Image UIimagen;
    public Text txt_aciertos;
    private static int aciertos;
    public Text txt_tiempo;
    float tiempores = 60;
    bool flag = false;
    int tiempof;

    public static int Aciertos
    {
        get
        {
            return aciertos;
        }

        set
        {
            aciertos = value;
        }
    }

    private void Start()
    {
        sourceCorrecto = GameObject.Find("SonidoCorrecto").GetComponent<AudioSource>();
        sourceError = GameObject.Find("SonidoError").GetComponent<AudioSource>();
        UIimagen = GameObject.Find("ImagenCel").GetComponent<Image>();
        txt_aciertos = GameObject.Find("Puntaje").GetComponent<Text>();
        mostrar = GameObject.FindGameObjectWithTag("mostrar").GetComponent<Text>();
        respuestat = GameObject.FindGameObjectWithTag("respuesta").GetComponent<Text>();
        sig = GameObject.FindGameObjectWithTag("sig").GetComponent<Button>();
        txt_tiempo = GameObject.Find("Tiempo").GetComponent<Text>();
        sig.interactable = false;
        mostrar.text = pregunta;
        txt_aciertos.text = "" + aciertos + " de 5";
        Empezar();
    }

    public void Empezar()
    {
        StartCoroutine(GetText());
    }

    public void Update()
    {
        tiempores = float.Parse(txt_tiempo.text);
        //Debug.Log("tiempo " + tiempores);
        if (tiempores <= 0)
        {
            sig.interactable = true;
            respuestat.text = "Se te acabo el tiempo";
        }
        else
        {
            if (flag == true)
            {
                CountDown cd = new CountDown();
                cd.cambiarBandera();
                txt_tiempo.text = "" + tiempof;
                sig.interactable = true;
                respuestat.text = "Puedes pasar al guiente reto!";
            }
        }
    }

    public void actualizarAciertos(int tem)
    {
        aciertos = tem;
    }

    IEnumerator GetText()
    {

        while (true)
        {
            UnityWebRequest www = new UnityWebRequest("http://" + DireccionIp + ":" + Puerto + "/");
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.Log("Error " + www.error);
            }
            else
            {
                // Show results as text
                Xml = www.downloadHandler.text;
                Debug.Log("[XML] " + Xml);

                if (string.IsNullOrEmpty(Xml))
                {


                    mostrar.text = "";
                    yield return new WaitForSeconds(1f);
                    continue;
                }



            }

            xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(Xml);
            foreach (XmlElement node in xmlDoc.SelectNodes("observacion"))
            {
                codigo = node.ChildNodes.Item(0).FirstChild.ChildNodes.Item(1).InnerText;
            }


            if (codigo.Equals(""))
            {
                Debug.Log("Ha llegado vacio");
            }
            else
            {

                if (codigo.Equals(Reticulo) && codigo.Equals(respuesta))
                {
                    aciertos++;
                    sourceCorrecto.Play();
                    UIimagen.sprite = Resources.Load<Sprite>("RecursosReto/Correcto");
                    respuestat.text = "Correcto";
                    cit = GameObject.FindGameObjectWithTag("Reticulo").GetComponent<Image>();
                    cit.enabled = true;
                    yield return new WaitForSeconds(2f);
                    cit.enabled = false;
                    UIimagen.sprite = Resources.Load<Sprite>("RecursosReto/CelulaReto");
                    sig.interactable = true;
                    Application.OpenURL("https://www.youtube.com/watch?v=xXG7lfUTCmM");
                    continue;
                    //CitoplasmaS.enabled = true;
                    //ImagenOrganelo.sprite = SCitoplasma;
                }
                else
                {
                    sourceError.Play();
                    UIimagen.sprite = Resources.Load<Sprite>("RecursosReto/Error");
                    respuestat.text = "Incorrecto";
                    yield return new WaitForSeconds(1f);
                    UIimagen.sprite = Resources.Load<Sprite>("RecursosReto/CelulaReto");
                    sig.interactable = true;
                    respuestat.text = "Incorrecto";
                    yield return new WaitForSeconds(2f);
                    respuestat.text = "";
                }
            }
            //Peticion5 aux = new Peticion5();
            //aux.actualizarAciertos(aciertos);
        }


    }



}
