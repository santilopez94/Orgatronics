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
    private Image mito;
    public void empezar()
    {
 
        StartCoroutine(GetText());
    }


   

    IEnumerator GetText()
    {

        while (true)
        {
            UnityWebRequest www = new UnityWebRequest("http://192.168.127.64:8080/");
            www.downloadHandler = new DownloadHandlerBuffer();
            yield return www.Send();

            if (www.isError)
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
            mostrar = GameObject.FindGameObjectWithTag("mostrar").GetComponent<Text>();
            if (codigo.Equals("2C00AC411D"))
            {
                mostrar.text = "Hola soy el reticulo endoplasmatico";
            }
            else if (codigo.Equals("2C00AC4309"))
            {
                mostrar.text = "Hola soy el nucleolo";
            }
            else if (codigo.Equals("28001D6E97"))
            {
                mostrar.text = "Hola soy el nucleo";
            }
            else if (codigo.Equals("2C00AC3649"))
            {
                mito.enabled = true;
                mostrar.text = "Hola soy la mitocondria";
                mito.transform.Rotate(Vector3.up, 10f * Time.deltaTime);
            }
            else if (codigo.Equals("2C00AC4351"))
            {
                mostrar.text = "Hola soy el citoplasma";
            }
        }

    }

    private void Start()
    {
        empezar();

    }



    public void Update()
    {

        timer = GameObject.FindGameObjectWithTag("Tiempo").GetComponent<Text>();
        iniciar = GameObject.FindGameObjectWithTag("boton").GetComponent<Button>();
        iniciar.interactable = false;
        mito = GameObject.FindGameObjectWithTag("mito").GetComponent<Image>();
        

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
