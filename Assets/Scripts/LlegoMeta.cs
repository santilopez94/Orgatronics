﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LlegoMeta : MonoBehaviour {

    public bool llego = false;
    private Text ganador;
   

    // Use this for initialization
    void Start () {
        ganador = GameObject.FindGameObjectWithTag("ganador").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("meta"))
        {
            Debug.Log("Entro a la meta");
            llego = true;
            ganador.enabled = true;
          
            


        }
    }
}