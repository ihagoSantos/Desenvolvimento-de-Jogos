using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTxtCredits : MonoBehaviour {

	public AudioClip efeitoClick;
	public AudioClip menuTheme;
	private AudioSource source;
	public Animator animationTxt;
	bool isRuning = true;
	void Start () {
		source = GetComponent<AudioSource>();
		source.PlayOneShot(menuTheme);
		animationTxt.Play("animationTxt");
	}
	
	// Update is called once per frame
	void Update () {
		
		
		

		if(!animationTxt.GetCurrentAnimatorStateInfo(0).IsName("animationTxt") || isRuning == false){
			Application.LoadLevel(0);

		}
	}

	void callAnimation(){
		animationTxt.Play("animationTxt");
		isRuning = false;
	}
}
