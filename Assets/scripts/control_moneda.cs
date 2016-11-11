using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class control_moneda : MonoBehaviour {

	private int monedas = 0;
	Text texto;

	void Start(){
		texto = GetComponent<Text> ();
		resetear ();
		suma_monedas (0);
	}
	public void suma_monedas(int cantidad){
		monedas = monedas + cantidad;
		if (monedas < 0) {
			monedas = 0;
		}
		texto.text = monedas.ToString ();
		Debug.Log("monedas: " +monedas);

	}
	public void resetear(){
		monedas = 0;
		texto.text = monedas.ToString ();
	}
}
