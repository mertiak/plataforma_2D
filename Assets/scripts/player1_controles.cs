using UnityEngine;
using System.Collections;

public class player1_controles : MonoBehaviour {
	public float velocidad = 5f;
	public float salto = 10f;
	public float power = 1f;
	public bool Tocando_suelo = true;
	private Animator anim;
	private Rigidbody2D rb;
	private Game_control_script gcs;
	public GameObject ParticulasMuerte;
	private AudioSource audio;
	public AudioClip sonido_salto;
	public AudioClip sonido_herir;
	public AudioClip sonido_moneda;
	private SpriteRenderer look;
	// Use this for initialization

	void Start () {
		anim = GetComponent<Animator> ();
		rb = GetComponent <Rigidbody2D> ();
		audio = GetComponent <AudioSource> ();
		gcs = GameObject.Find ("game_control").GetComponent<Game_control_script> ();
		look = GetComponent<SpriteRenderer> ();
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
			audio.PlayOneShot (sonido_salto);
		}
	
	
	}

	void OnTriggerStay2D(Collider2D objeto){
		if (objeto.tag == "suelo") {
			Tocando_suelo = true;
			anim.SetBool ("Jump", false);
		}
	} 

	void OnTriggerExit2D(Collider2D objeto){
		if (objeto.tag == "suelo") {
			Tocando_suelo = false;
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "enemigo") {
			Invoke ("muerte",1);
			Debug.Log ("Enemigo Tocado");
			audio.PlayOneShot (sonido_herir);
			//gcs.respaw ();
			Instantiate(ParticulasMuerte,transform.position,transform.rotation);
			look.enabled = false;
		}
		if (col.gameObject.tag == "moneda") {
			audio.Play ();
			Debug.Log("sonido");
		}
	}
	void muerte(){
		gcs.respaw ();
		look.enabled = true;
	}




}
