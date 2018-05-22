using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Peticion : MonoBehaviour {

    // Use this for initialization
    private Text timer;
    private Button iniciar;
    private Text mostrar;
    private float tiempo = 10f;
    private string Xml;
    private XmlDocument xmlDoc;
    private string codigo;
    private Image ImagenOrganelo;
    private string Mensaje;


    /*Datos del servidor*/
    private string DireccionIp = "192.168.100.138";
    private string Puerto = "8080";

    /*Codigo Tags de los organelos*/
    private static string Nucleo = "28001D6E97";
    private static string Nucleolo = "2C00AC4309";
    private static string Citoplasma = "2C00AC4351";
    private static string Reticulo = "2C00AC411D";
    private static string Mitocondria = "2C00AC3649";

    /*Sprite organelos*/
    public Sprite SCitoplasma;
    public Sprite SNucleo;


    private void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Tiempo").GetComponent<Text>();
        iniciar = GameObject.FindGameObjectWithTag("boton").GetComponent<Button>();
        ImagenOrganelo = GameObject.FindGameObjectWithTag("mito").GetComponent<Image>();
        mostrar = GameObject.FindGameObjectWithTag("mostrar").GetComponent<Text>();
        
        Empezar();
    }

    public void Empezar()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {

        while (true)
        {
            UnityWebRequest www = new UnityWebRequest("http://"+ DireccionIp +":"+ Puerto + "/");
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.Send();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Xml = www.downloadHandler.text;
                Debug.Log(Xml);

                if (string.IsNullOrEmpty(Xml))
                {
                    ImagenOrganelo.enabled = false;
                    mostrar.text = "";
                    yield return new WaitForSeconds(1f);
                    continue;
                }

                // Or retrieve results as binary data
                byte[] results = www.downloadHandler.data;
            }

            xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(Xml);
            foreach (XmlElement node in xmlDoc.SelectNodes("observacion"))
            {
                codigo = node.ChildNodes.Item(0).FirstChild.ChildNodes.Item(1).InnerText;
            }
            Debug.Log(codigo);

            if (codigo.Equals(Reticulo))
            {
                mostrar.text = "Hola soy el reticulo endoplasmatico";
            }
            else if (codigo.Equals(Nucleolo))
            {
                mostrar.text = "Hola soy el nucleolo";
            }
            else if (codigo.Equals(Nucleo))
            {
                mostrar.text = "Hola soy el nucleo";
            }
            else if (codigo.Equals(Mitocondria))
            {
                mostrar.text = "Hola soy la mitocondria";
                ImagenOrganelo.enabled = true;
                //ImagenOrganelo.transform.Rotate(Vector3.up, 10f * Time.deltaTime);
            }
            else if (codigo.Equals(Citoplasma))
            {
                mostrar.text = "Hola soy el citoplasma";
                ImagenOrganelo.enabled = true;
                //ImagenOrganelo.sprite = SCitoplasma;
            }
        }
    }

    public void Update()
    {
        iniciar.interactable = false;
        
        tiempo -= Time.deltaTime;
        if(tiempo<0.0f)
        {
            //Debug.Break();
            iniciar.interactable = true;
            timer.enabled = false;
        }
        timer.text = " " + tiempo.ToString("f0");
    }


}
