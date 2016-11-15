using UnityEngine;
using System.Collections;

public class Script_checkpoint : MonoBehaviour {
	private Game_control_script gcs;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		gcs = GameObject.Find ("game_control").GetComponent<Game_control_script> ();
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D objeto) {
		if (objeto.tag == ("Player")) {
			gcs.checkpoint (transform.position);
			anim.SetBool ("mov", true);
		}
	}
}
