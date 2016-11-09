using UnityEngine;
using System.Collections;

public class player1_controles : MonoBehaviour {
	public float velocidad = 5f;
	public float salto = 10f;
	public float power = 1f;
	public bool Tocando_suelo = true;
	private Animator anim;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent <Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		anim.SetFloat ("velocidad", Mathf.Abs (rb.velocity.x));
		if (Input.GetKey (KeyCode.LeftArrow)) {
			anim.SetFloat ("velocidad", 1f);
			rb.velocity = new Vector2 (-velocidad * power, rb.velocity.y);
			transform.localScale = new Vector3 (-1, 1, 1);
		} 
		else if (Input.GetKey(KeyCode.RightArrow)) {
			anim.SetFloat ("velocidad", 1f);
			rb.velocity = new Vector2 (velocidad * power, rb.velocity.y);
			transform.localScale = new Vector3 (1, 1, 1);
		}
	
		//if (Input.GetKeyUp (KeyCode.LeftArrow)) {
		//	anim.SetFloat ("velocidad", 0f);
		//} 
		//else if (Input.GetKeyUp (KeyCode.RightArrow)) {
		//	anim.SetFloat ("velocidad", 0f);
		//}

		if (Input.GetKeyDown (KeyCode.Space) && Tocando_suelo) {
			anim.SetBool("Jump",true);
			rb.AddForce (transform.up*salto);
			Debug.Log ("Salto");
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			anim.SetBool ("Jump", false);
		}
	
	}
	void OnTriggerStay2D(Collider2D objeto){
		if (objeto.tag == "suelo") {
			Tocando_suelo = true;
		}
	} 
	void OnTriggerExit2D(Collider2D objeto){
		if (objeto.tag == "suelo") {
			Tocando_suelo = false;
		}
	}
}
