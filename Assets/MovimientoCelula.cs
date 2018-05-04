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
    private Text contador;
    private float tiempo = 60f;
   
    // Use this for initialization
    void Start () {
        contador = GameObject.FindObjectOfType<Text>();
        contador.text = " " + tiempo;
        energy = GameObject.FindObjectOfType<Slider>();
        
	}
    
  
	
	// Update is called once per frame
	void Update () 
	{
        tiempo -= Time.deltaTime;
        contador.text = " " + tiempo.ToString("f0");

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
        stopray = Physics.Raycast(transform.position, Vector3.forward, 0.05f);
        if (stopray.ToString().Equals("True"))
        {
            cont++;
            if (cont == 1)
            {
                Destroy(GameObject.FindGameObjectWithTag("rayo"));
                energy.value=0.7f;
            }
            if (cont == 2)
            {
                Destroy(GameObject.FindGameObjectWithTag("rayo1"));
                energy.value = 0.8f;
            }
            if (cont == 3)
            {
                Destroy(GameObject.FindGameObjectWithTag("rayo2"));
                energy.value = 0.9f;

            }
            if (cont == 4)
            {
                Destroy(GameObject.FindGameObjectWithTag("rayo3"));
                energy.value = 1.0f;

            }
            



        }

        Debug.Log("Numero de rayos" + cont);
    }



}
