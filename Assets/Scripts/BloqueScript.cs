using UnityEngine;
using System.Collections;

public class BloqueScript : MonoBehaviour {

	public FiguraScript figPadre;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		
	}
	
	private void OnTriggerEnter2D(){
		Debug.Log("choco");
		if(figPadre.estado!=4){
			figPadre.estado = 3;
			StartCoroutine("Asentar");
		}
	}
	
	private IEnumerator Asentar(){

		Vector3 pos; 
		bool negativo=true; 

		yield return new WaitForSeconds(0.5f);
		if(figPadre.estado == 3){
			figPadre.estado = 4;
			Vector2 aux = figPadre.rigidbody2D.velocity;
			aux.x = 0;
			figPadre.rigidbody2D.velocity = aux;
//			Destroy(figPadre.GetComponent("Rigidbody2D"));
			Control.getInstancia.crearFigura();
			pos = figPadre.transform.position;

			if(pos.y<0)
				negativo = true;
			
			pos.y = Mathf.Floor(Mathf.Abs(pos.y*4))/4;

			if(negativo)
				pos.y *= -1;

			figPadre.transform.position = pos;
			figPadre.rigidbody2D.isKinematic = true;
		}
		//
		//		if(Control.figuraActiva != null){
		//			Control.getFiguraActiva.asentado = true;
		//			Vector2 aux = Control.getFiguraActiva.rigidbody2D.velocity;
		//			aux.x = 0;
		//			Control.getFiguraActiva.rigidbody2D.velocity = aux;
		//			
		////			Vector3 aux2 = Control.figuraActiva.transform.position;
		////			aux2.x = Mathf.Round((aux2.x - 0.25f)*2)/2+0.25f;
		////			Control.figuraActiva.transform.position = aux2;
		////			
		//			Control.figuraActiva = null;
		//			if(Control.figuraActiva == null){
		//				Debug.Log("entro");
		//				StartCoroutine("EsperarAsentar");
		//			}
		//		}
	}
}
