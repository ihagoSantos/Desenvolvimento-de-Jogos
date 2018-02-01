using UnityEngine;
using System.Collections;

public class HP_Bar : MonoBehaviour {
    public TextMesh HPMesh;//Guarda a quantidade de HP atual do player
    public SpriteRenderer vida;//variavel para guarda a sprite do HP
    private float HPTotal;
    private ControllerLife player = null;

    // Use this for initialization
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<ControllerLife>();
        this.HPTotal = this.player.getVidaTotal();
    }

    void Update()
    {
        this.exibirHPtext();
        this.alterarHP();
    }

    private void exibirHPtext()
    {
        //Debug.Log(this.player.getVidaAtual());
        this.HPMesh.text = this.player.getVidaAtual() + "";

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
        float porcHP = this.player.getVidaAtual() / HPTotal;
        float x = calcularX(porcHP);
        Vector2 vec2 = new Vector2(porcHP, vida.transform.localScale.y);
        this.vida.transform.localPosition = new Vector3(x, 0, 0);
        this.vida.transform.localScale = vec2;//ajusta a escala da barra em funçao da porcentagem de HP

    }
}
