using UnityEngine;
using System.Collections;

public class moneda : MonoBehaviour {
	private Rigidbody2D rb;
	GameObject texto_moneda;
	control_moneda cm;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody2D> ();
		//rb.AddForce (new Vector2 (Random.Range (-100, 100),100));
		texto_moneda = GameObject.Find ("texto_moneda");
		cm = texto_moneda.GetComponent<control_moneda> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Player") {
			cm.suma_monedas (5);
			Destroy (gameObject);
		}
	}
}
