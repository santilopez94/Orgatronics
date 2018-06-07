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
    //public Slider energy;
    private GameObject BarraEnergia;
    public string nivel;
    private Text[] contador;
    private Text timer;
    private Text nivelt;
    private Text puntaje;
    //private Text multiplicadort;
    public float tiempo;
    /*Contador puntaje*/
    public int puntuacion = 0;

    private int totalpuntaje;
    //private string multi = "X1";
    private ParticleSystem ps;
    public bool llego;

    private Vector3 movFrame;

    /*Sonidos celula*/
    public AudioClip sonidoRayo;
    public AudioClip sonidoMeta;
    private AudioSource source;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
        timer = GameObject.FindGameObjectWithTag("Tiempo").GetComponent<Text>();
        nivelt = GameObject.FindGameObjectWithTag("nivel").GetComponent<Text>();
        puntaje = GameObject.FindGameObjectWithTag("puntaje").GetComponent<Text>();
        //multiplicadort = GameObject.FindGameObjectWithTag("multiplicador").GetComponent<Text>();
        BarraEnergia = GameObject.Find("BarraEnergia");
        //energy = GameObject.FindGameObjectWithTag("energiab").GetComponent<Slider>();

        ps = GameObject.FindObjectOfType<ParticleSystem>();
        ps.Stop();
        if (nivel.Equals("1"))
        {
            tiempo = 60;
        }
        if (nivel.Equals("2"))
        {
            tiempo = 120;
        }

    }

    // Update is called once per frame
    void Update()
    {

        
        //Si no ha llegado a la meta, disminuya
        if (llego == false) {
            if (tiempo > 0)
            {
                tiempo -= Time.deltaTime;
            }
        }
        timer.text = " " + tiempo.ToString("f0");


        GameObject go = GameObject.Find("Meta");
        LlegoMeta meta = go.GetComponent<LlegoMeta>();
        llego = meta.llego;
        
        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
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


        if (llego == false)
        {
            MoverZ(velocidad * Time.deltaTime);
        }
        else if (llego == true)
        {
            transform.Translate(0f * Time.deltaTime * Vector3.forward);
        }
        if(debeMoverse)
            Moverse();
        
        
    }
    private bool debeMoverse = false;
    private void Moverse()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + movFrame);
        movFrame = Vector3.zero;
        debeMoverse = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (nivel.Equals("1"))
        {
            if (other.gameObject.CompareTag("rayo1"))
            {
                Debug.Log("Detectando colision");
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (3)"));
                //energy.value = 70;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (other.gameObject.CompareTag("rayo2"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (4)"));
                //energy.value = 80;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (other.gameObject.CompareTag("rayo3"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (5)"));
                //energy.value = 90;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (other.gameObject.CompareTag("rayo4"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (6)"));
                //energy.value = 100;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }

          
            /*if (energy.value == 100)
            {
                source.PlayOneShot(sonidoMeta, 0.1f);
                multiplicadort.text = "X2";
                ps.Play();
                var color = ps.main;
                color.startColor = Color.yellow;
            }*/
            
        }
        if (nivel.Equals("2"))
        {
            //float actualener = energy.value;

            if (other.gameObject.CompareTag("rayo1"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (3)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
                //Math.Round(actualener);
            }
            if (other.gameObject.CompareTag("rayo2"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (4)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
                //Math.Round(actualener);
            }
            if (other.gameObject.CompareTag("rayo3"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (5)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
                //Math.Round(actualener);
            }
            if (other.gameObject.CompareTag("rayo4"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (6)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
                //Math.Round(actualener);
            }
            if (other.gameObject.CompareTag("rayo5"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (7)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
                //Math.Round(actualener);
            }
            if (other.gameObject.CompareTag("rayo6"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (8)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (other.gameObject.CompareTag("rayo7"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (9)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (other.gameObject.CompareTag("rayo8"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (10)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (other.gameObject.CompareTag("rayo9"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (11)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (other.gameObject.CompareTag("rayo10"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (12)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (other.gameObject.CompareTag("rayo11"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (13)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (other.gameObject.CompareTag("rayo12"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (14)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (other.gameObject.CompareTag("rayo13"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (15)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (other.gameObject.CompareTag("rayo14"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (16)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (other.gameObject.CompareTag("rayo15"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (17)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }
            if (other.gameObject.CompareTag("rayo16"))
            {
                source.PlayOneShot(sonidoRayo, 1f);
                Destroy(GameObject.Find("rayo (18)"));
                //energy.value = actualener + 2.5f;
                totalpuntaje = totalpuntaje + 100;
                puntaje.text = " " + totalpuntaje;
            }

            /*if (energy.value == 100)
            {
                source.PlayOneShot(sonidoMeta, 0.1f);
                multiplicadort.text = "X2";
                ps.Play();
                var color = ps.main;
                color.startColor = Color.yellow;
            }*/
        }

        }

    private void MoverIzquierda()
    {
        MoverX(-3f * velocidad * Time.deltaTime);
    }

    private void MoverX(float valor)
    {
        Vector3 posOriginal = transform.position;
        movFrame += new Vector3(valor, 0, 0);
        debeMoverse = true;
    }

    private void MoverZ(float valor)
    {
       
        movFrame += new Vector3(0, 0, valor);
        debeMoverse = true;
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
