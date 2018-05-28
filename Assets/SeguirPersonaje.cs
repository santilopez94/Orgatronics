using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirPersonaje : MonoBehaviour {

    public Transform personaje;
    public float separacion = 3f;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        //Actualiza la posicion de la camara segun el personaje. Solo modifica la posicion z
        transform.position = new Vector3(transform.position.x, transform.position.y, personaje.position.z+separacion);
    }
}
