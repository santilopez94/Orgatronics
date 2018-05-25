using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovEne : MonoBehaviour
{
    public float velocidad;
   
    public bool stopbac;
    private string nivel;
    private AudioSource sonido;

    private Vector3 dirActual = Vector3.right;


    public float distRayo = 1;

    // Use this for initialization
    void Start()
    {
        sonido = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool stopr = false;
        bool stopiz = false;

        if(IsMovingIzquierda)
            stopiz = Physics.Raycast(transform.position, Vector3.left, distRayo, LayerMask.GetMask("enemigos"));
        if(IsMovingDerecha)
            stopr = Physics.Raycast(transform.position, Vector3.right, distRayo, LayerMask.GetMask("enemigos"));        
        

        if (stopr)
        {
            dirActual = Vector3.left;
        }

        if (stopiz)
        {
            dirActual = Vector3.right;
        }
        transform.Translate(velocidad * Time.deltaTime * dirActual);
        
    }

    public bool IsMovingIzquierda
    {
        get
        {
            return dirActual.x < 0;
        }
    }

    public bool IsMovingDerecha
    {
        get
        {
            return dirActual.x > 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        GameObject go = GameObject.Find("Celula");
        MovimientoCelula cel = go.GetComponent<MovimientoCelula>();
        nivel = cel.nivel;
        if (nivel.Equals("1"))
        {
            if (other.gameObject.CompareTag("cel"))
            {
                sonido.Play();
                Debug.Log("Entro en la celula");
                Destroy(GameObject.Find("Celula"));
                SceneManager.LoadScene("Escena1");

            }
        }
        if (nivel.Equals("2"))
        {
            if (other.gameObject.CompareTag("cel"))
            {
                sonido.Play();
                Destroy(GameObject.Find("Celula"));
                SceneManager.LoadScene("Nivel2");

            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * distRayo);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * distRayo);
    }



}

    


    

