using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Peticion : MonoBehaviour {

    // Use this for initialization
    private Text timer;
    private Text mostrar;
    private Text respuestat;
    private float tiempo = 10f;
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
    private string DireccionIp = "192.168.127.19";
    private string Puerto = "8080";

    /*Codigo Tags de los organelos*/
   
    private static string Citoplasma = "2C00AC4351";
   
    
    private string pregunta= "¿Cual parte de la celula se encarga de albergar los organelos y contribuir al movimiento de estos?";
    private string respuesta = "2C00AC4351";
    private int aleatorio;



    private void Start()
    {

        mostrar = GameObject.FindGameObjectWithTag("mostrar").GetComponent<Text>();
        respuestat = GameObject.FindGameObjectWithTag("respuesta").GetComponent<Text>();
        sig= GameObject.FindGameObjectWithTag("sig").GetComponent<Button>();
        sig.interactable = false; 
        mostrar.text = pregunta;
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
                      
                if (codigo.Equals(Citoplasma) && codigo.Equals(respuesta))
                {
                    respuestat.text = "Correcto";
                    cit = GameObject.FindGameObjectWithTag("Citoplasma").GetComponent<Image>();
                    cit.enabled = true;
                    yield return new WaitForSeconds(2f);
                    cit.enabled = false;
                    sig.interactable = true;
                    Application.OpenURL("https://www.youtube.com/watch?v=b-hyqOM-4aA");
                    continue;
                    //CitoplasmaS.enabled = true;
                    //ImagenOrganelo.sprite = SCitoplasma;
                }
                else
                {
                    respuestat.text = "Incorrecto";
                    yield return new WaitForSeconds(2f);
                    respuestat.text = "";
                }
            }
        }


    }
    


}
