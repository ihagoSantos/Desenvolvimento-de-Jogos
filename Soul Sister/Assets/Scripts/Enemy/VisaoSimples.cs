using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisaoSimples : MonoBehaviour {

    private float largura = 300;
    private float abertura = 100;
    private float raio = 10;
    private float altura;
    public bool vendoPlayer = false;

	// Use this for initialization
	void Start () {
        transform.localScale = new Vector3(largura, abertura, raio);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("É nois colidindo " + other.tag);
            this.vendoPlayer = true;
        }     

    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player")) {
            Debug.Log("É nois colidindo " + other.tag);
            this.vendoPlayer = true;
        }

    }
    */
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player")) {
            Debug.Log("saiu da visão " + other.tag);
            this.vendoPlayer = false;
        }

    }

    public bool getVendoPlayer()
    {
        return this.vendoPlayer;
    }

    public void setAltura(float altura)
    {
        transform.position = new Vector3(transform.position.x, altura, transform.position.z);
    }

    public void setLargura(float largura)
    {
        transform.localScale = new Vector3(largura, transform.localScale.y, transform.localScale.z);
    }

    public void setAbertura(float abertura)
    {
        transform.localScale = new Vector3(transform.localScale.x, abertura, transform.localScale.z);
    }

    public void setRaio(float raio)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, raio);
    }
}
