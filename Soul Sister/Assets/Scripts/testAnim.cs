using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAnim : MonoBehaviour {
    [SerializeField]
    private Animator enemyAnimator;
    private float tempoAnim = 0;
    private float tempoAtual = 0;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        tempoAtual = 0;
        this.AnimAttack();

    }

    private void cancelarAnimacoes()
    {
        this.enemyAnimator.SetBool("idle", false);
        this.enemyAnimator.SetBool("moviment", false);
        this.enemyAnimator.SetBool("morrer", false);
        this.enemyAnimator.SetBool("receberDano", false);
        this.enemyAnimator.SetBool("attack", false);

    }

    protected void animIdle()
    {
        this.enemyAnimator.SetTrigger("idle");
    }
    protected void animMovement()
    {
        this.enemyAnimator.SetTrigger("moviment");
    }
    protected void animMorrer()
    {
        this.enemyAnimator.SetTrigger("morrer");
    }
    protected void animReceberDano()
    {
        this.enemyAnimator.SetTrigger("receberDano");
    }
    protected void AnimAttack()
    {
        this.enemyAnimator.SetTrigger("attack");
        //this.tempoAtual = 0;

    }
}
