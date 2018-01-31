using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrulharLinhaReta : Patrulhar {
    private float distancia;
    public Vector3 vetorPercorrido;
    private Vector3 posInicial;
    public PatrulharLinhaReta(NavMeshAgent nav,Vector3 posInicial,float distancia) : base(nav)
    {
        this.posInicial = posInicial;
        this.setDistancia(distancia);
    }

    public override void patrulharMethod()
    {


          if(Mathf.Round(this.nav.transform.position.x) == Mathf.Round(this.vetorPercorrido.x) && Mathf.Round(this.nav.transform.position.z) == Mathf.Round(this.vetorPercorrido.z))
          {
 
              this.setDistancia(-1 * this.distancia);
          }

           this.nav.SetDestination(this.vetorPercorrido);
        

    }

    public void setDistancia(float distancia)
    {
        this.distancia = distancia;
        this.vetorPercorrido = new Vector3(this.posInicial.x + this.distancia, this.posInicial.y, this.posInicial.z + this.distancia);
    }


}
