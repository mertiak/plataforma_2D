using UnityEngine;
using System.Collections;

public class rana : MonoBehaviour {
	Animator animacion;

	// Use this for initialization
	void Start () {
		animacion = GetComponent<Animator> ();

	
	}
	
	// Update is called once per frame
	void OnTriggerStay2D(Collider2D objeto) {
		if (objeto.tag == "Player") {
			animacion.SetTrigger ("salto");
		}


	}
		

}
