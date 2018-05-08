﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovEne : MonoBehaviour
{
    public float velocidad;
    public bool stopr;
    public bool stopiz;
    public bool stopbac;
  

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        stopr = Physics.Raycast(transform.position, Vector3.right, .5f);
        stopiz = Physics.Raycast(transform.position, Vector3.left, .5f);

        if (transform.position.x < 5 && stopr==true)
        {
            velocidad = 2;
        }

        if (transform.position.x >= 5 && stopiz==true)
        {
            velocidad = -2;
        }
        transform.Translate(velocidad * Time.deltaTime, 0, 0);
        
    }

    private void FixedUpdate()
    {
        stopbac = Physics.Raycast(transform.position, Vector3.forward, 0.05f);
        if(stopbac==true && GameObject.FindGameObjectWithTag("cel").tag.Equals("cel"))
        {
            Destroy(GameObject.Find("Celula"));
            Application.LoadLevel(0);
        }
    }


    }
