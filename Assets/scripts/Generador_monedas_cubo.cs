using UnityEngine;
using System.Collections;

public class Generador_monedas_cubo : MonoBehaviour {
	public GameObject[] monedas;
	private GameObject moneda_nueva;
	private Transform pos_salida;
	private int numero_moneda = 0;
	private Animator anim;

	// Use this for initialization
	void Start (){
		pos_salida = transform.Find ("posicion_salida").transform;
		Debug.Log ("cantidad de monedas" + monedas.Length);
		anim = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			numero_moneda = Random.Range (0, monedas.Length);
			moneda_nueva = (GameObject)Instantiate (monedas[numero_moneda],
				pos_salida.position,
				transform.rotation);
		}
	
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			anim.SetBool ("contacto", true);
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			anim.SetBool ("contacto", false);
		}
	}
	

}
