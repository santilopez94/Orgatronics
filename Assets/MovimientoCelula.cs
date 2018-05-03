using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCelula : MonoBehaviour {

	public float velocidad;
    public bool stopr;
    public bool stopiz;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
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
    }
   


}
