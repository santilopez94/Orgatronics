using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    private Text TextoTiempo;
    public float Tiempo = 0.0f;
    private bool Parar = false;
	// Use this for initialization
	void Start () {
        TextoTiempo = GameObject.FindGameObjectWithTag("Tiempo").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Tiempo >= 0 && Parar == false)
        {
            Tiempo -= Time.deltaTime;
            TextoTiempo.text = "" + Tiempo.ToString("f0");
        }        
    }

}
