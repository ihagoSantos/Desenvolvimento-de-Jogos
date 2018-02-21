using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_BAR_INIMIGO : MonoBehaviour {

    private TextMesh HPMesh;//Guarda a quantidade de HP atual do player
    private SpriteRenderer vida;//variavel para guarda a sprite do HP
    private SpriteRenderer background;//variavel para guarda a sprite do HP
    private float HPTotal;
    private ControllerLife inimigo = null;
    private GameObject player;
    private float tempo = 0;
    [SerializeField]
    private float tempoHide = 5;
    private float hpAnterior;

    // Use this for initialization
    void Start()
    {
        this.inimigo = GetComponentInParent<ControllerLife>();
        this.HPTotal = this.inimigo.getVidaTotal();
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.HPMesh = GetComponentInChildren<TextMesh>();
        SpriteRenderer[] r = GetComponentsInChildren<SpriteRenderer>();
        this.vida = r[0];
        this.background = r[1];
        this.hpAnterior = this.inimigo.getVidaAtual();
        this.hide();
        Debug.Log("start hp inimigo");
    }

    void Update()
    {
        //Debug.Log("updade inimigo hp");
      
        this.tempo += Time.deltaTime;
        this.hpMudou();
        if(this.tempo == 5) {
            this.hide();
        }
    }

    private void exibirHPtext()
    {
        //Debug.Log(this.player.getVidaAtual());
        this.HPMesh.text = this.inimigo.getVidaAtual() + "";

    }

    //calcula o quanto o eixo x vai se desocar na sprite da vida
    //responsavel pela "animaçao" da barra de vida(faz ela descer) 
    float calcularX(float porcHP)
    {
        float x;//variavel para o eixo x
        x = -2 * (1 - porcHP);
        return x;
    }
    //Funçao responsavel por atualizar a GUI da vida
    public void alterarHP()
    {
        float porcHP = this.inimigo.getVidaAtual() / HPTotal;
        Debug.Log("total "+HPTotal);
        Debug.Log(this.inimigo.getVidaAtual());
        float x = calcularX(porcHP);
        Vector2 vec2 = new Vector2(porcHP, vida.transform.localScale.y);
        this.vida.transform.localPosition = new Vector3(x, 0, 0);
        this.vida.transform.localScale = vec2;//ajusta a escala da barra em funçao da porcentagem de HP

    }

    private void show()
    {
        this.vida.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.background.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        this.HPMesh.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.exibirHPtext();
        this.alterarHP();
    }

    private void hide()
    {
        this.vida.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.background.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.HPMesh.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void hpMudou()
    {
        if(this.inimigo.getVidaAtual() != this.hpAnterior) {
            Debug.Log("hpMudou");
            this.hpAnterior = this.inimigo.getVidaAtual();
            this.tempo = 0;
            this.show();
        }
    }
}
