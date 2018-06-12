using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Peticion5: MonoBehaviour
{
    private Text mostrar;
    private string Xml;
    private XmlDocument xmlDoc;
    private Button sig;

    private string Mensaje;

    /*Datos del servidor*/
    private string DireccionIp = "192.168.127.6";
    private string Puerto = "8080";
    
    public AudioSource sourceFelicitacion;
    public AudioSource sourceGameOver;
    public Image UIimagen;
    public Text txt_puntaje;
    public int aciertos;
    //public static int aciertos=0;
    public Text txt_tiempo;
    float tiempores = 60;
    bool flag = false;
    int tiempof;

    private void Start()
    {
        txt_puntaje = GameObject.Find("Puntaje").GetComponent<Text>();
        mostrar = GameObject.FindGameObjectWithTag("mostrar").GetComponent<Text>();
        sig = GameObject.FindGameObjectWithTag("sig").GetComponent<Button>();
        sig.interactable = false;
        mostrar.text = "";
        aciertos = Peticion4.Aciertos;
        //txt_puntaje.text = "" + aciertos + " de 5";
        Empezar();
    }

    public void Empezar()
    {
        StartCoroutine(GetText());
    }

    public void actualizarAciertos(int tem)
    {
        aciertos = tem;
    }

    IEnumerator GetText()
    {
        while (true)
        { 
            if (aciertos>=3)
            {
                txt_puntaje.text = "" + aciertos + " de 5";
                mostrar.text = "HAS GANADO";
                sourceFelicitacion.Play();
                sig.interactable = true;
                yield return new WaitForSeconds(3f);
                break;
            }
            else
            {
                txt_puntaje.text = "" + aciertos + " de 5";
                mostrar.text = "HAS PERDIDO";
                sourceGameOver.Play();
                sig.interactable = true;
                yield return new WaitForSeconds(3f);
                break;  
            }
        }


    }



}
