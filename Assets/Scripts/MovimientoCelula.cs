using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovimientoCelula : MonoBehaviour
{

    public float velocidad;
    public bool stopr;
    public bool stopiz;
    public bool stopAdelante;
    private int cont;
    private int numrayos;
    public Slider energy;
    public string nivel;
    private Text[] contador;
    private Text timer;
    private Text nivelt;
    private Text puntaje;
    private Text multiplicadort;
    private float tiempo = 60f;
    private int puntajeint = 0000;
    private int totalpuntaje;
    private string multi = "X1";
    private ParticleSystem ps;
    public bool llego;


    // Use this for initialization
    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Tiempo").GetComponent<Text>();
        nivelt = GameObject.FindGameObjectWithTag("nivel").GetComponent<Text>();
        puntaje = GameObject.FindGameObjectWithTag("puntaje").GetComponent<Text>();
        multiplicadort = GameObject.FindGameObjectWithTag("multiplicador").GetComponent<Text>();
        energy = GameObject.FindGameObjectWithTag("energiab").GetComponent<Slider>();
        ps = GameObject.FindObjectOfType<ParticleSystem>();
        ps.Stop();
    }



    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("Meta");
        LlegoMeta meta = go.GetComponent<LlegoMeta>();
        llego = meta.llego;
        
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            velocidad = 10f;
            int w = Screen.width;

            Vector3 p = Input.mousePosition;
            if (!stopr)
            {
                //Si la posición es mayor que la mitad del ancho
                if (p.x > w / 2)
                {
                    MoverDerecha();
                }
            }
            if (!stopiz)
            {
                if (p.x <= w / 2)
                {
                    MoverIzquierda();
                }
            }
        }
        if (stopAdelante) {
            Debug.Log("Esta entrando");
            velocidad = 0f;
            transform.Translate(velocidad * Time.deltaTime * Vector3.forward);
        }

        if (llego == false)
        {
            tiempo -= Time.deltaTime;
            transform.Translate(velocidad * Time.deltaTime * Vector3.forward);
        }
        else if (llego == true && stopAdelante == false)
        {
            transform.Translate(0f * Time.deltaTime * Vector3.forward);
        }
        timer.text = " " + tiempo.ToString("f0");
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("rayo"))
        {
            cont++;
            if (cont == 1)
            {
                Destroy(GameObject.Find("rayo (3)"));
                energy.value = 0.7f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (cont == 2)
            {
                Destroy(GameObject.Find("rayo (4)"));
                energy.value = 0.8f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (cont == 3)
            {
                Destroy(GameObject.Find("rayo (5)"));
                energy.value = 0.9f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (cont == 4)
            {
                Destroy(GameObject.Find("rayo (6)"));
                energy.value = 1.0f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (energy.value == 1.0f)
            {
                multiplicadort.text = "X2";
                ps.Play();
                var color = ps.main;
                color.startColor = Color.yellow;
            }
        }
    }

    private void MoverIzquierda()
    {
        MoverX(-3f * velocidad * Time.deltaTime);
    }

    private void MoverX(float valor)
    {
        Vector3 posOriginal = transform.position;
        transform.position = new Vector3(posOriginal.x + valor, posOriginal.y, posOriginal.z);
    }

    private void MoverDerecha()
    {
        MoverX(3f * velocidad * Time.deltaTime);
    }



    private void FixedUpdate()
    {
        stopr = Physics.Raycast(transform.position, Vector3.right, 3f);
        stopiz = Physics.Raycast(transform.position, Vector3.left, 3f);
        /*if (GameObject.FindGameObjectWithTag("pared").tag.Equals("pared")) {
            stopAdelante = Physics.Raycast(transform.position, Vector3.forward, 3f);
        }*/
        // Debug.Log("Numero de rayos" + cont);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * 3f);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * 3f);
        //Gizmos.DrawLine(transform.position, transform.position + Vector3.forward * 3f);
    }

}