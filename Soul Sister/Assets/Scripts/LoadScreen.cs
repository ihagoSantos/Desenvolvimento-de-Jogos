using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreen : MonoBehaviour {

	private AudioSource source;
	public AudioClip efeitoClick;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void backEvents(){
		source.PlayOneShot(efeitoClick);
		Application.LoadLevel(1);
	}
}
