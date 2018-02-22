using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

public class EnemyBehavior : MonoBehaviour {
    private Transform player;
    private NavMeshAgent nav;
    //Objeto que informa o tipo forma que o inimigo usará para seguir o jogador
    private FollowPlayerMode followPlayerObj;
    private Patrulhar patrulharObj;
    [SerializeField]
    private Enumerates.seguir followMode;
    [SerializeField]
    private Enumerates.patrulhar modoPatrulha;
    private ControllerLife controllerLife;
    [SerializeField]
    private Enumerates.estadoComportamento aoVerPlayer;
    [SerializeField]
    private Enumerates.estadoComportamento aoPerderPlayer;
    [SerializeField]
    private Enumerates.estadoComportamento estadoDefaut;
    [SerializeField]
    private Enumerates.estadoComportamento aoVoltarPosicaoInicial;
    [SerializeField]
    private Enumerates.estadoComportamento aoReceberDano;
    [SerializeField]
    private Enumerates.estadoComportamento aoPlayerSeAproximar;
    [SerializeField]
    private Enumerates.estadoComportamento aoPlayerSeAfastar;
    [SerializeField]
    private Enumerates.estadoComportamento estadoAtual;//Informa qual comportamento o inimigo está executando
    [SerializeField]
    private float alturaDeVisao = 1;
    [SerializeField]
    private float raioDeVisao = 1;
    [SerializeField]
    private float larguraDeVisao = 300;
    [SerializeField]
    private float aberturaDeVisao = 100;
    [SerializeField]
    private float tempoDesistirDeSeguir = 10;
    [SerializeField]
    private float distanciaDeAtk = 1;
    [SerializeField]
    private float velOlhar = 1;
    [SerializeField]
    private float distanciaPatrulha = 5;
    [SerializeField]
    private Animator enemyAnimator;
    private float timer = 0;
    public float distanciaDoPlayer;
    private Vector3 posInicial;
    private VisaoSimples visao;
    private bool viuPlayerAntes = false;
    private Arma arma;


    // Use this for initialization
    void Start () {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        this.nav = GetComponent<NavMeshAgent> ();
        Status stBase = GetComponent<Status>();
        this.controllerLife = GetComponent<ControllerLife>();
        this.controllerLife.inicializar(stBase);
        this.controllerLife.setEstadoAtual(Enumerates.estadoDeVida.Vivo);
        this.posInicial = new Vector3((float)Math.Round(transform.position.x, 1), 0, (float)Math.Round(transform.position.z, 1));
        this.arma = GetComponentInChildren<Arma>();
        Debug.Log(this.posInicial);
        this.visao = GetComponentInChildren<VisaoSimples>();
        this.selectFollowMode();
        this.selecionarModoDePatrulhar();
        Debug.Log("start");
    }
	
	// Update is called once per frame
	void Update () {
        this.observar();
        this.distanciaDoPlayer = Vector3.Distance(transform.position, this.player.position);
        if (this.controllerLife.getEstadoAtual().Equals(Enumerates.estadoDeVida.Vivo))
        {
            this.arma.setAtk(false);
            if (this.estadoAtual.Equals(Enumerates.estadoComportamento.IDLE))
            {
                this.animIdle();
                //Faz animação de idle     
            }
            else if (this.estadoAtual.Equals(Enumerates.estadoComportamento.SEGUIR))
            {
                this.animMovement();
                if (this.distanciaDoPlayer <= distanciaDeAtk) {
                    Debug.Log("ficou menor");
                    this.estadoAtual = Enumerates.estadoComportamento.ATACAR;
                }
                else {
                    this.followPlayer();
                }
            }
            else if (this.estadoAtual.Equals(Enumerates.estadoComportamento.PATRULHAR))
            {
                this.animMovement();
                this.patrulharObj.patrulharMethod();
               // Debug.Log(((PatrulharLinhaReta)this.patrulharObj).vetorPercorrido);
            }
            else if (this.estadoAtual.Equals(Enumerates.estadoComportamento.ATACAR))
            {
                //Debug.Log("Entrou no atacando");
                this.nav.SetDestination(transform.position);
                if (distanciaDoPlayer > this.distanciaDeAtk && this.visao.getVendoPlayer())
                {
                    Debug.Log("vou seguir");
                    this.estadoAtual = this.aoPlayerSeAfastar;
                }
                else if(distanciaDoPlayer > this.distanciaDeAtk && this.visao.getVendoPlayer() == false)
                {
                    this.estadoAtual = this.aoPerderPlayer;
                }
                else
                {
                    this.animAttack();
                    //faz o que é referente ao ataque
                    //provavelmente executa animação
                    //Debug.Log("atacando");
                    this.arma.setAtk(true);
                    //Esse trecho a abaixo é só para teste da arma
                    //this.arma.setPosition(new Vector3(0, 0, 1.6f));
                    //this.arma.setPosition(new Vector3(0, 0, -0.5f));
                }
            }
            else if (this.estadoAtual.Equals(Enumerates.estadoComportamento.RECEBERDANO)) {
                this.animReceberDano();
                transform.LookAt(this.player);
                this.estadoAtual = this.aoReceberDano;

            }
            else if (this.estadoAtual.Equals(Enumerates.estadoComportamento.VOLTARPISICAOINICIAL))
            {
                this.animMovement();
                //Debug.Log("voltando");
                this.nav.SetDestination(this.posInicial);
                if (transform.position.x == this.posInicial.x && transform.position.z == this.posInicial.z)
                {
                    //Debug.Log("chegeu na pos inicial");
                    this.estadoAtual = this.aoVoltarPosicaoInicial;
                }
            }
        }
        else {
            this.animMorrer();
            Destroy(gameObject,2);
        }

    }


    private void selectFollowMode()
    {
        if (this.followMode == Enumerates.seguir.SIMPLES)//Forma simples, segue o player tentando chegar junto dele para atacar
        {
            this.followPlayerObj = new FollowPlayerSimple(this.nav, this.player);
        }
    }

    private void selecionarModoDePatrulhar()
    {
        if (this.modoPatrulha == Enumerates.patrulhar.LINHARETA) {
            this.patrulharObj = new PatrulharLinhaReta(this.nav,this.posInicial, this.distanciaPatrulha);
        }
    }
    //Método que realiza ação de seguir o jogador
    private void followPlayer()
    {

        // Debug.Log("seguindo "+this.followPlayerObj);
        //transform.LookAt(this.player);

            this.followPlayerObj.trackPlayer();
        

    }

    //Método que representa a visão no inimigo
    private void observar()
    {

        timer += Time.deltaTime;
        
        //Só usado para depurar
        /*
        this.visao.setAbertura(this.aberturaDeVisao);
        this.visao.setAltura(this.alturaDeVisao);
        this.visao.setLargura(this.larguraDeVisao);
        this.visao.setRaio(this.raioDeVisao);
        */
        //Debug.Log(timer);
        if (this.visao.getVendoPlayer() && this.distanciaDoPlayer <= this.distanciaDeAtk && this.estadoAtual.Equals(Enumerates.estadoComportamento.IDLE)) {
            this.estadoAtual = this.aoPlayerSeAproximar;
        }
        else if (this.visao.getVendoPlayer() && this.estadoAtual!= Enumerates.estadoComportamento.ATACAR && this.estadoAtual != this.aoPlayerSeAfastar)
        {
           // Debug.Log("vi ele");
            this.estadoAtual = this.aoVerPlayer;
            this.viuPlayerAntes = true;
            timer = 0;
        }

        else if(this.visao.getVendoPlayer() == false && timer >= this.tempoDesistirDeSeguir && this.viuPlayerAntes)
        {
           // Debug.Log("Perdi ele ");
            timer = 0;
            this.estadoAtual = this.aoPerderPlayer;
            this.viuPlayerAntes = false;
        }
        else if (this.visao.getVendoPlayer()) {
            timer = 0;
            this.viuPlayerAntes = true;
        }

    }

    public void setEstadoComp(Enumerates.estadoComportamento estado)
    {
        this.estadoAtual = estado;
    }
    /*
    private void viuPlayer(RaycastHit hit)
    {
        Debug.Log("entrou no viuPlayer");
        Debug.Log(hit.collider.gameObject.tag);

            Debug.Log("Detectou colisão");
            this.estadoAtual = this.aoVerPlayer;
            this.viuPlayerAntes = true;
            this.timer = 0;
            transform.LookAt(this.player);//Olha para a direção do jogador
        

    }*/
    /*
    private void rotacionar()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(this.player.position-transform.position), Time.deltaTime*this.velOlhar);
    }
    */

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("É nois colidindo "+ other.tag);
        }

    }
    */
    
    protected void animIdle() {
        this.enemyAnimator.SetTrigger("idle");
    }
    protected void animMovement() {
        this.enemyAnimator.SetTrigger("moviment");
    }
    protected void animMorrer() {
        this.enemyAnimator.SetTrigger("morrer");
    }
    protected void animReceberDano() {
        this.enemyAnimator.SetTrigger("receberDano");
    }
    protected void animAttack() {

        this.enemyAnimator.SetTrigger("attack");
    }
}
