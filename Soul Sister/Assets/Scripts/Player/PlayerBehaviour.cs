using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f;
    private ControllerLife controllerLife;
    private Vector3 forward, right;
    [SerializeField]
    private float tempoParaIdle = 100;
    [SerializeField]
    private Enumerates.estadoComportamento estadoComp = Enumerates.estadoComportamento.DEFAULT;
    private float tempo = 0;
    private Arma arma;
    private Vector3 initialPosition;

    // Use this for initialization
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        this.controllerLife = GetComponent<ControllerLife>();
        Status [] sts = GetComponents<Status>();
        Status stBase = sts[0];
        Status stBonus = sts[1];
        this.inicializarArma();
        this.controllerLife.inicializar(stBase, stBonus);
        this.initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.tempo = Time.deltaTime;
        if (this.controllerLife.getEstadoAtual() == Enumerates.estadoDeVida.Vivo) {
            if(this.estadoComp == Enumerates.estadoComportamento.IDLE) {
                //ANIMACAO DE IDLE
            }
            else if(this.estadoComp == Enumerates.estadoComportamento.ATACAR) {
                this.atacar();
            }

            else if(Input.anyKey) {
                //Debug.Log("aki");
                Move();
            }
            this.deveEntrarEmIdle();
        }

    }

    void Move()
    {
        this.tempo = 0;
        this.estadoComp = Enumerates.estadoComportamento.DEFAULT;
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        //Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        //transform.forward = heading;
        transform.position += rightMovement * 2f;
        transform.position += upMovement * 2f;
    }

    private void deveEntrarEmIdle()
    {
        if (this.tempo == this.tempoParaIdle) {
            this.estadoComp = Enumerates.estadoComportamento.IDLE;
        }
    }

    private void inicializarArma()
    {
        try {
            this.arma = GetComponentInChildren<Arma>();
        }catch(Exception e) {
            //nada
        }
    }

    private void atacar()
    {
        if (this.arma != null) {
            this.arma.setAtk(true);
        }
    }
}