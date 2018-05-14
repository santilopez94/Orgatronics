using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovimientoCelula : MonoBehaviour {

	public float velocidad;
    public bool stopr;
    public bool stopiz;
    public bool stopray;
    private int cont;
    private int numrayos;
    public Slider energy;
    public string nivel;
    private Text[] contador;
    private float tiempo = 60f;
    private int puntajeint = 0000;
    private int totalpuntaje;
    private string multi="X1";
    private ParticleSystem ps;
    
   
    // Use this for initialization
    void Start () {
        contador = GameObject.FindObjectsOfType<Text>();

        contador[0].text = " " + tiempo;
        contador[1].text = " " + puntajeint;
        contador[2].text = " " + multi;
        contador[3].text = "" + nivel;
        energy = GameObject.FindObjectOfType<Slider>();
        for(int i=0;i<contador.Length;i++)
        {
            Debug.Log("Textos" +i  +contador[i]);
        }
        ps = GameObject.FindObjectOfType<ParticleSystem>();
        ps.Stop();
        
	}
    
  
	
	// Update is called once per frame
	void Update () 
	{
        tiempo -= Time.deltaTime;
        contador[0].text = " " + tiempo.ToString("f0");

        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            //Debug.Log("Tocado");

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

                //Mover derecha
                //Si es menor
                //Mover izquierda

            }

        transform.Translate(velocidad * Time.deltaTime * Vector3.forward);
       

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
                contador[1].text = " " + totalpuntaje;
            }
            if (cont == 2)
            {
                Destroy(GameObject.Find("rayo (4)"));
                energy.value = 0.8f;
                totalpuntaje = totalpuntaje + 100;
                contador[1].text = " " + totalpuntaje;
            }
            if (cont == 3)
            {
                Destroy(GameObject.Find("rayo (5)"));
                energy.value = 0.9f;
                totalpuntaje = totalpuntaje + 100;
                contador[1].text = " " + totalpuntaje;


            }
            if (cont == 4)
            {
                Destroy(GameObject.Find("rayo (6)"));
                energy.value = 1.0f;
                totalpuntaje = totalpuntaje + 100;
                contador[1].text = " " + totalpuntaje;

            }
            if (energy.value == 1.0f)
            {
                contador[2].text = "X2";
                ps.Play();
                var color = ps.main;
                color.startColor = Color.yellow;


            }
        }
    }

    private void MoverIzquierda()
    {

		MoverX(- 3f * velocidad*Time.deltaTime);
    }

	private void MoverX(float valor)
	{
		Vector3 posOriginal = transform.position;
        transform.position = new Vector3(posOriginal.x + valor, posOriginal.y, posOriginal.z);
        
	}

    private void MoverDerecha()
    {
        MoverX(3f * velocidad*Time.deltaTime);
    }
   


    private void FixedUpdate()
    {
        stopr = Physics.Raycast(transform.position, Vector3.right, .67f);
        stopiz = Physics.Raycast(transform.position, Vector3.left, .67f);
      
       
        // Debug.Log("Numero de rayos" + cont);
    }



}
