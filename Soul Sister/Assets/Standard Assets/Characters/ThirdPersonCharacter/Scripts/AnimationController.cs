using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationState{
	IDLE,
	WALK,
	RUN
}
public class AnimationController : MonoBehaviour {

	public Animator animator;

	public void PlayAnimation(AnimationState currentAnimation){

		switch(currentAnimation){

			case AnimationState.IDLE:
				{
					StopAnimations ();
					animator.SetBool ("inIdle", true);
				}
				break;
			case AnimationState.WALK:
				{
					StopAnimations ();
					animator.SetBool ("inWalk", true);
				}
				break;
			case AnimationState.RUN:
				{
					StopAnimations ();
					animator.SetBool ("inRun", true);
				}
				break;
			}
	}

	void StopAnimations(){
		animator.SetBool ("inIdle", false);
		animator.SetBool ("inWalk", false);
		animator.SetBool ("inRun", false);
	}
}
