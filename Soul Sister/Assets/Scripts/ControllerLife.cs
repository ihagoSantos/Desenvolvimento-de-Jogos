using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLife : MonoBehaviour {

    private Enumerates.estadoDeVida estadoAtual;

    [SerializeField]
    private Status status;//Status defaut (sem modificadores)
    [SerializeField]
    private Status statusAtual; //Status Atuais (que são exibidos e atualizados)
    [SerializeField]
    private Status statusBonus; //Status bônus vindos de alguma arma ou item 

    [SerializeField]
    private float vidaTotal; 
    private float danoPersonagem;

    //Multiplicadores caso seja preciso que um mesmo tipo de inimigo ou o player precise receba um buff ou debuff
    [SerializeField]
    private float multDanoRecebido = 1;
    /*
    [SerializeField]
    private float multDanoCausado = 1;*/

    public void inicializar(Status status)
    {
        this.statusAtual = new Status(0, 0, 0);
        this.status = status;
        this.setStatusBonus(new Status(0,0,0));
        this.estadoAtual = Enumerates.estadoDeVida.Vivo;
    }

    public void inicializar(Status status, Status statusBonus)
    {
        this.statusAtual = new Status(0, 0, 0);
        this.status = status;
        this.setStatusBonus(statusBonus);
        this.estadoAtual = Enumerates.estadoDeVida.Vivo;
    }

    public void receberDano(float dano)
    {
        float vidaRestante = this.calcularDanoRecebido(dano);
        if (vidaRestante <= 0)
        {
            this.morrer();
            vidaRestante = 0;
        }
        this.statusAtual.setVida(vidaRestante);
    }

    public void recuperarVida(float vida)
    {
        float vidaRecuperada = this.statusAtual.getVida() + vida;
        if (vidaRecuperada > this.vidaTotal)
        {
            this.encherVida();
        }
        else
        {
           this.statusAtual.setVida(vidaRecuperada);
        }
    }

    /*
    public float causarDano()
    {
        return this.danoTotal*this.multDanoCausado;
    }*/

    public void encherVida()
    {
        this.statusAtual.setVida(this.vidaTotal);
    }


    public void upar(Status st)
    {
        this.status = st;
        this.atualizarStatusAtual();

    }

    //Recupera a quantidade de vida atual;
    public float getVidaAtual()
    {
        //Debug.Log(this.status.getVida());
        return this.statusAtual.getVida();
    }

    public float getVidaTotal()
    {
        return this.vidaTotal;
    }

    public float getDano()
    {
        return this.danoPersonagem;
    }

    //Recupera o estado em que se encontra o ser(Vivo ou morto)
    public Enumerates.estadoDeVida getEstadoAtual()
    {
        return this.estadoAtual;
    }

    public void setEstadoAtual(Enumerates.estadoDeVida estado)
    {
        this.estadoAtual = estado;
    }

    public void setStatusBonus(Status st)
    {
        this.statusBonus = st;
        this.atualizarStatusAtual();
    }


    private void morrer()
    {
        this.estadoAtual = Enumerates.estadoDeVida.Morto;
        //TODO aki vai ter algo a mais depois
    }

    private void atualizarStatusAtual()
    {
        this.vidaTotal = this.statusBonus.getVida() + this.status.getVida();
        this.danoPersonagem = this.statusBonus.getDano() + this.status.getDano();

        this.statusAtual.setVida(this.vidaTotal);
        this.statusAtual.setDano(this.danoPersonagem);
        this.statusAtual.setDefesa(this.statusBonus.getDefesa() + this.status.getDefesa());
    }

    private float calcularDanoRecebido(float dano)
    {
        float danoR = this.statusAtual.getDefesa() - dano * this.multDanoRecebido;
        if (danoR >= 0) {
            danoR = 1;
        }
        Debug.Log("levei " + danoR);
        return this.statusAtual.getVida() + danoR;
    }

}
