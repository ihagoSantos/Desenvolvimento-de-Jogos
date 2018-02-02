using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerMouse : MonoBehaviour {

    public Transform lookAt;
    public Transform camTranform;

    private const float Y_ANGLE_MIN = 0;
    private const float Y_ANGLE_MAX = 50;

    private Camera cam;
    private float distance = 10f;
    private float currentX = 0;
    private float currentY = 0;
    private float sensivityX = 4f;
    private float sensivityY = 1;

	// Use this for initialization
	void Start () {
        camTranform = transform;
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        this.currentX += Input.GetAxis("Mouse X");
        this.currentY += Input.GetAxis("Mouse Y");

        this.currentY = Mathf.Clamp(this.currentY,Y_ANGLE_MIN,Y_ANGLE_MAX);
	}

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotacao = Quaternion.Euler(this.currentY, currentX, 0);
        camTranform.position = lookAt.position + rotacao * dir;
        camTranform.LookAt(lookAt.position);
    }
}
