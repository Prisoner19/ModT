using UnityEngine;
using System.Collections;

public class BloqueScript : MonoBehaviour {

	private bool tiempo_asentar;

	// Use this for initialization
	void Start () {
		tiempo_asentar = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D(Collision2D coll){

	}

	private void OnTriggerEnter2D(){

		StartCoroutine("Asentar");
	}

	private IEnumerator Asentar(){
	
		yield return new WaitForSeconds(0.5f);
		Control.getFiguraActiva.asentado = true;
		Vector2 aux = Control.getFiguraActiva.rigidbody2D.velocity;
		aux.x = 0;
		Control.getFiguraActiva.rigidbody2D.velocity = aux;
		
		Vector3 aux2 = Control.figuraActiva.transform.position;
		aux2.x = Mathf.Round((aux2.x - 0.25f)*2)/2+0.25f;
		Control.figuraActiva.transform.position = aux2;
		
		Control.figuraActiva = null;
		if(Control.figuraActiva == null){
			Control.getInstancia.crearFigura();
		}
	}
	
	private IEnumerator Esperar(float tiempo){

		yield return new WaitForSeconds(tiempo);
		tiempo_asentar = true;
		Debug.Log("entro");

	}
}
