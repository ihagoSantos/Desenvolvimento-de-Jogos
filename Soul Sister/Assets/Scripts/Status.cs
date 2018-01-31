using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {
    /*
     * Classe responsável por representar os status tanto do player quanto dos inimigos
     */
    [SerializeField]
    private float vida;
    [SerializeField]
    private float dano;
    [SerializeField]
    private float defesa;

    public Status(float vida,float dano,float defesa)
    {
        this.vida = vida;
        this.dano = dano;
        this.defesa = defesa;
    }

    public float getVida()
    {
        return this.vida;
    }

    public float getDano()
    {
        return this.dano;
    }

    public float getDefesa()
    {
        return this.defesa;
    }

    public void setDano(float dano)
    {
        this.dano = dano;
    }

    public void setDefesa(float defesa)
    {
        this.defesa = defesa;
    }

    public void setVida(float vida)
    {
        this.vida = vida;
    }
}
