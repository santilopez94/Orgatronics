using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Pausa : MonoBehaviour {

    bool activado;
    Image ImagenPausa;
    Text textoPausa;
    Button BotonPausa;

    // Use this for initialization
    void Start() {
        ImagenPausa = GameObject.FindGameObjectWithTag("ImagenPausa").GetComponent<Image>();
        BotonPausa = GameObject.FindGameObjectWithTag("BotonPausa").GetComponent<Button>();
        textoPausa = GameObject.FindGameObjectWithTag("TextoPausa").GetComponent<Text>();
        activado = false;
        ImagenPausa.enabled = activado;
        textoPausa.enabled = activado;
	}
	
    
	// Update is called once per frame
	public void Pausar () {
        //if (Input.GetKeyDown("space")) {
            activado = !activado;
            ImagenPausa.enabled = activado;
            textoPausa.enabled = activado;
            //Tiempo del juego.
            //Activada la pausa colocar 0, de lo contrario 1
            Time.timeScale = (activado) ? 0 : 1;
        //}
	}

}
