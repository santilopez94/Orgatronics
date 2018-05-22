using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celula2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.MovePosition(transform.position + Time.deltaTime * transform.forward);
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("multiplicador"))
        {
            Destroy(other.gameObject);
            GetComponent<AudioSource>().Play();
            
        }
    }


}
