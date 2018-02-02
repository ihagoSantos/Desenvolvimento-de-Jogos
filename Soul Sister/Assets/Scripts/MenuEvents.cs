using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEvents : MonoBehaviour {

	public AudioClip efeitoClick;
	public AudioClip menuTheme;
	private AudioSource source;
	


	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		source.PlayOneShot(menuTheme);
		 
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void newGameEvent(){
		
		source.PlayOneShot(efeitoClick);
		Application.LoadLevel(2);
	
	}

	public void loadEvent(){

		source.PlayOneShot(efeitoClick);
		Application.LoadLevel(1);
	
	}

	public void creditsEvent(){
		source.PlayOneShot(efeitoClick);
		Application.LoadLevel(4);
	}
	public void backToMenuEvent(){
		source.PlayOneShot(efeitoClick);
		Application.LoadLevel(0);
	}

}
