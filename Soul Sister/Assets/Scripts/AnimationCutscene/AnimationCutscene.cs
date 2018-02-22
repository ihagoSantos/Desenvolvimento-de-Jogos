using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimationCutscene : MonoBehaviour {

	public float transicao;
	public float entradaLogo;
	public float saidaLogo;
	public float tempoAtual;

	public float entradaNomes;
	public float saidaNomes;

	public Image logo;
	public Image nomes;


	// Use this for initialization
	void Start () {

		logo.fillAmount = 0f;
		nomes.fillAmount = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		this.tempoAtual += 1;

		if (this.tempoAtual >= entradaNomes && this.tempoAtual < saidaNomes) {
			nomes.fillAmount += transicao;
		}
		if (this.tempoAtual >= saidaNomes) {
			nomes.fillAmount -= transicao;
		}


		if (this.tempoAtual >= entradaLogo && this.tempoAtual < saidaLogo) {
			logo.fillAmount += transicao;
		}

		if (this.tempoAtual >= saidaLogo) {
			logo.fillAmount -= transicao;
		}



	}
}
