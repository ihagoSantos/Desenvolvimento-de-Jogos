using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Post_Cutscene : MonoBehaviour {

	public float tempoAtual ;
	public float tempoParar ;
	private AudioSource source;
	public AudioClip efeitoClick;



	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();

	}

	// Update is called once per frame
	void Update () {
		this.tempoAtual += 1f;
		if(this.tempoAtual == this.tempoParar){
			Application.LoadLevel(2);
		}
	}
	public void skipCutscene(){

		source.PlayOneShot(efeitoClick);
		Application.LoadLevel(2);

	}

}