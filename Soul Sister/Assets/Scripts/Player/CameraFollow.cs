using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    /*
     *Esse script é responsavel por fazer a câmera seguir o jogador.
     */
    private GameObject player;
    Vector3 cameraOffset;
    
    [SerializeField]
    private float deslocamentoX = -6;
    [SerializeField]
    private float deslocamentoY = 6;
    [SerializeField]
    private float deslocamentoZ = -8;
    
    // Use this for initialization
    void Start () {
        this.player = GameObject.FindGameObjectWithTag("Player");
         this.cameraOffset = new Vector3(transform.position.x, transform.position.y, transform.position.z);//Deslocamento para o câmera não ficar "dentro" do player
        this.cameraOffset = new Vector3(this.deslocamentoX, this.deslocamentoY, this.deslocamentoZ);//Deslocamento para o câmera não ficar "dentro" do player
    }
	
	// Update is called once per frame
	void Update () {
        this.cameraOffset = new Vector3(this.deslocamentoX, this.deslocamentoY, this.deslocamentoZ);
        transform.position = this.player.transform.position + this.cameraOffset;
    }
}
