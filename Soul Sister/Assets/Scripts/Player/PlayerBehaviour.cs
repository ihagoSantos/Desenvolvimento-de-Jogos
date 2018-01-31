using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 4f;

    private ControllerLife controllerLife;

    private Vector3 forward, right;

    // Use this for initialization
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        this.controllerLife = GetComponent<ControllerLife>();
        Status [] sts = GetComponents<Status>();
        Status stBase = sts[0];
        Status stBonus = sts[1];
        this.controllerLife.inicializar(stBase, stBonus);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
            Move();
    }

    void Move()
    {
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        //Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        //transform.forward = heading;
        transform.position += rightMovement * 2f;
        transform.position += upMovement * 2f;
    }
}