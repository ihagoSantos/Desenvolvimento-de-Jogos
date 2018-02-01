using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

    private float danoTotal;
    [SerializeField]
    private float danoBase = 1;
    [SerializeField]
    private float multDanoCausado = 1;
    [SerializeField]
    private Enumerates.tipoCriatura tipo;
    [SerializeField]
    private bool atacando = false;
    private ControllerLife portadorController;

    // Use this for initialization
    void Start () {
        this.portadorController = GetComponentInParent<ControllerLife>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void calcularDanoTotal()
    {
        this.danoTotal = (danoBase + this.portadorController.getDano()) * this.multDanoCausado;
    }

    
    private void causarDano(ControllerLife alvoAtingido)
    {
        if (this.atacando) {
            this.calcularDanoTotal();
            alvoAtingido.receberDano(this.danoTotal);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (tipo == Enumerates.tipoCriatura.INIMIGO && other.gameObject.tag=="Player") {
            Debug.Log("causouDano");
            this.causarDano(other.GetComponent<ControllerLife>());
        }
        else if(tipo == Enumerates.tipoCriatura.PLAYER && other.gameObject.tag == "Enemy") {
            this.causarDano(other.GetComponent<ControllerLife>());
        }
    }

    public void setAtk(bool atk)
    {
        this.atacando = atk;
    }

    public void setPosition(Vector3 vector)
    {
        transform.localPosition = vector;
    }

}
