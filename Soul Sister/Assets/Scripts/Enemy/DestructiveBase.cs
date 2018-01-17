using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestructiveBase : MonoBehaviour {

	public float currentLife;

	// Use this for initialization
	protected void Start () {
		
	}
	
	// Update is called once per frame
	protected void Update () {
		
	}

	public void applyDamage(int damage){

		currentLife-=damage;

		if(currentLife <= 0){
			OnDestroyed();
		}
	}

	public abstract void OnDestroyed();
}
