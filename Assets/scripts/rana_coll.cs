using UnityEngine;
using System.Collections;

public class rana_coll : MonoBehaviour {

	GameObject texto_moneda;
	control_moneda cm;

	// Use this for initialization
	void Start () {
		texto_moneda = GameObject.Find ("texto_moneda");
		cm = texto_moneda.GetComponent<control_moneda> ();
	}
	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Player") {
			cm.suma_monedas (-3);
		}
	}
}