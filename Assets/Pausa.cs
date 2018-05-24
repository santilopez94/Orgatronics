using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour {

    bool activado;
    Canvas canvas;

	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")) {
            activado = !activado;
            canvas.enabled = activado;
            //Tiempo del juego.
            //Activada la pausa colocar 0, de lo contrario 1
            Time.timeScale = (activado) ? 0 : 1;
        }
	}
}
