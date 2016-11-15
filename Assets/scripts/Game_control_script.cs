using UnityEngine;
using System.Collections;

public class Game_control_script : MonoBehaviour {

	private Vector3 punto_inicio;
	public GameObject player1;
	public bool vivo = true;

	void Start (){
		Debug.Log ("Punto Inicio");
		punto_inicio = player1.transform.position;
	}
	public void respaw(){
		player1.transform.localPosition = punto_inicio;
		Debug.Log ("Respawn:" + punto_inicio.ToString());
	}
	public void checkpoint(Vector3 nuevo_punto){
		punto_inicio = nuevo_punto;
	}
}
