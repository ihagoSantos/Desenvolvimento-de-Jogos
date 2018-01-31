using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour {

    private float danoTotal;
    [SerializeField]
    private float danoBase = 1;
    [SerializeField]
    private float multDanoCausado = 1;
    private ControllerLife portadorController;
    // Use this for initialization
    void Start () {
        this.portadorController = GetComponent<ControllerLife>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void calcularDanoTotal()
    {
        this.danoTotal = (danoBase + this.portadorController.getDano()) * this.multDanoCausado;
    }

    
    public void causarDano(ControllerLife alvoAtingido)
    {
        if (this.portadorController.getEstadoAtual().Equals(Enumerates.estadoComportamento.ATACAR))
        {
            this.calcularDanoTotal();
            alvoAtingido.receberDano(this.danoTotal);
        }
    }

}
