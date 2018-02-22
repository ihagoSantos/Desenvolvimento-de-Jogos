using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Post_Cutscene : MonoBehaviour {

	public float tempoAtual ;
	public float tempoParar ;



	// Use this for initialization
	void Start () {


	}

	// Update is called once per frame
	void Update () {
		this.tempoAtual += 1f;
		if(this.tempoAtual == this.tempoParar){
			Application.LoadLevel(2);
		}
	}

}