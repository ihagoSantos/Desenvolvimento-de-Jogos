using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public abstract class FollowPlayerMode : MonoBehaviour {
    protected Transform player;
    protected Transform initialPosition;
    protected NavMeshAgent nav;

    public FollowPlayerMode(NavMeshAgent nav, Transform player)
    {
        this.player = player;
        this.nav = nav;
    }

    public abstract void trackPlayer();

}
