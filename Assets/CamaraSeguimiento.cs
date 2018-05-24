using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour {

    //Objeto a seguir
    public GameObject seguido;
    //Para limitar la posicion de la camara
    //Minima y maxima posicion de la camara 
    public Vector3 minCamPos, maxCamPos;

    //segundos de retardo o suavizado
    public float smoothTime;

    private Vector3 velocidad;

	// Use this for initialization
	void Start () {
		
	}

    // Se ejecuta el mismo numero de veces que el 
    //frame rate del juego. Update->cada vez que
    //el pc pueda
    void FixedUpdate() {
        //Obtenemos la posicion del objeto a seguir
        float posY = seguido.transform.position.y;
        float posZ = seguido.transform.position.z;

        /*
         * float posY = Mathf.SmoothDamp(transform.position.y, seguido.transform.position.y,
            ref velocidad.y, smoothTime);
            float posZ = Mathf.SmoothDamp(transform.position.z, seguido.transform.position.z,
                ref velocidad.z, smoothTime);
         */
        //Cambiamos la posicion de la camara
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(posY, minCamPos.y, maxCamPos.y),
            Mathf.Clamp(posZ, minCamPos.z, maxCamPos.z));
    }
}
