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
    private Text mostrar;
    private float tiempo = 10f;
    private string Xml;
    private XmlDocument xmlDoc;
    private string codigo;
    private Image mito;
    private Image nuc;
    private Image nuco;
    private Image ret;
    private Image cit;
    /*Sprite organelos*/
    //private Image MitocondriaS;
    //private Image NucleoS;
    //private Image NucleoloS;
    //private Image ReticuloS;
    //private Image CitoplasmaS;

    private string Mensaje;

    /*Datos del servidor*/
    private string DireccionIp = "192.168.137.181";
    private string Puerto = "8080";

    /*Codigo Tags de los organelos*/
    private static string Nucleo = "28001D6E97";
    private static string Nucleolo = "2C00AC4309";
    private static string Citoplasma = "2C00AC4351";
    private static string Reticulo = "2C00AC411D";
    private static string Mitocondria = "2C00AC3649";

    


    private void Start()
    {

        mostrar = GameObject.FindGameObjectWithTag("mostrar").GetComponent<Text>();
       
        
        //MitocondriaS = GameObject.FindGameObjectWithTag("Mitocondria").GetComponent<Image>();
        //CitoplasmaS = GameObject.FindGameObjectWithTag("Citoplasma").GetComponent<Image>();
        //NucleoS = GameObject.FindGameObjectWithTag("Nucleo").GetComponent<Image>();
        //NucleoloS = GameObject.FindGameObjectWithTag("Nucleolo").GetComponent<Image>();
        //ReticuloS = GameObject.FindGameObjectWithTag("Reticulo").GetComponent<Image>();

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
                Debug.Log("Error "+ www.error);
            }
            else
            {
                // Show results as text
                Xml = www.downloadHandler.text;
                Debug.Log("[XML] "+Xml);

                if (string.IsNullOrEmpty(Xml))
                {


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
                ret = GameObject.FindGameObjectWithTag("Reticulo").GetComponent<Image>();
                ret.enabled = true;
                yield return new WaitForSeconds(2f);
                ret.enabled = false;
                continue;
                //ReticuloS.enabled = true;

            }
            else if (codigo.Equals(Nucleolo))
            {
                mostrar.text = "Hola soy el nucleolo";
                nuco= GameObject.FindGameObjectWithTag("Nucleolo").GetComponent<Image>();
                nuco.enabled = true;
                yield return new WaitForSeconds(2f);
                nuco.enabled = false;
                continue;
                //NucleoloS.enabled = true;
            }
            else if (codigo.Equals(Nucleo))
            {
                mostrar.text = "Hola soy el nucleo";
                //NucleoS.enabled = true
                nuc = GameObject.FindGameObjectWithTag("Nucleo").GetComponent<Image>();
                nuc.enabled = true;
                yield return new WaitForSeconds(2f);
                nuc.enabled = false;
                continue;


            }
            else if (codigo.Equals(Mitocondria))
            {
                mito = GameObject.FindGameObjectWithTag("Mitocondria").GetComponent<Image>();
                mito.enabled = true;
                mostrar.text = "Hola soy la mitocondria";
                yield return new WaitForSeconds(2f);
                mito.enabled = false;
                continue;
                //MitocondriaS.enabled = true;
                //ImagenOrganelo.transform.Rotate(Vector3.up, 10f * Time.deltaTime);
            }
            else if (codigo.Equals(Citoplasma))
            {
                mostrar.text = "Hola soy el citoplasma";
                cit = GameObject.FindGameObjectWithTag("Citoplasma").GetComponent<Image>();
                cit.enabled = true;
                yield return new WaitForSeconds(2f);
                cit.enabled = false;
                continue;
                //CitoplasmaS.enabled = true;
                //ImagenOrganelo.sprite = SCitoplasma;
            }
        }
    }

    


}
