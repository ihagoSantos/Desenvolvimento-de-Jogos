using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public abstract class Patrulhar : MonoBehaviour {
    protected Transform initialPosition;
    protected NavMeshAgent nav;

    public Patrulhar(NavMeshAgent nav)
    {
        this.nav = nav;
    }

    public abstract void patrulharMethod();

}
