using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscenaPrincipal : MonoBehaviour {

    public int Velocidad = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, Velocidad, 0));
	}
}
