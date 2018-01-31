using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerSimple : FollowPlayerMode {

    public FollowPlayerSimple(NavMeshAgent nav, Transform player) : base(nav, player)
    {
    }

    public override void trackPlayer()
    {
        this.nav.SetDestination(player.position);
    }

}
