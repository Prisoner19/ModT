using UnityEngine;
using System.Collections;

public class BloqueScript : MonoBehaviour {

	public FiguraScript figPadre;
	private bool fijo;
	private bool inicioCongelado;
	private int linea;
	private Vector3 posDrag;
	private bool clickStarted;
	private bool clickEnded;

	// Use this for initialization
	void Start () {
		fijo = false;
		inicioCongelado = false;
		linea = 0;
		posDrag = Vector3.zero;
		clickStarted = false;
		clickEnded = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(figPadre.estado == 4 && !fijo){
			transform.parent = null;
			linea = Mathf.FloorToInt((transform.position.y + 4.75f)*2);
			transform.parent = Control.getInstancia.lineas[linea].transform;
			fijo = true;
			figPadre.num_bloques--;
			if(figPadre.num_bloques==0)
				GameObject.Destroy(figPadre.gameObject);
			Destroy(gameObject.GetComponent("BloqueScript"));
		}

		if(figPadre.estado == 1 && !inicioCongelado){
			transform.parent = null;
			inicioCongelado = true;
		}

		if(figPadre.estado == 2 && inicioCongelado){
			transform.parent = figPadre.transform;
			inicioCongelado = false;
		}

		if(clickEnded){
			if(Input.GetMouseButtonDown(0)){
				posDrag = Input.mousePosition;
				posDrag.x = (Input.mousePosition.x -240)/80;
				posDrag.y = (Input.mousePosition.y -400)/80;
				posDrag.x = Mathf.Round((posDrag.x - 0.25f)*2) /2 + 0.25f;
				posDrag.y = Mathf.Round((posDrag.y - 0.25f)*2) /2 + 0.25f;
				posDrag.z = 0;
				transform.position = posDrag;
				transform.localScale -= new Vector3(0.2f,0.2f,0);
				clickEnded = false;
				Debug.Log("Hey");
			}
		}
	}
	
//	void OnMouseDrag(){
//		posDrag = transform.position;
//		posDrag.x = (Input.mousePosition.x -240)/80;
//		posDrag.y = (Input.mousePosition.y -400)/80;
//		posDrag.z = -1;
//
//		posDrag.y = (((Mathf.Floor(((posDrag.y*4)+1)/2))*2)-1)/4;
//		if(posDrag.y<0){
//			posDrag.y = Mathf.Floor(Mathf.Abs(posDrag.y*4))/4;
//			posDrag.y *= -1;
//		}
//		else{
//			posDrag.y = Mathf.Round(Mathf.Abs(posDrag.y*4))/4;
//		}
//		posDrag.x = Mathf.Round((posDrag.x - 0.25f)*2) /2 + 0.25f;
//
//		transform.position = posDrag;
//	}

	private void OnMouseDown(){
		if(!clickStarted){
			transform.localScale += new Vector3(0.2f,0.2f,0);
			clickStarted = true;
			Debug.Log("Clicked!");
		}
	}

	private void OnMouseUp(){
		if(clickStarted){
			clickEnded = true;
			clickStarted = false;
		}
	}

	private void OnTriggerEnter2D(){
		Debug.Log("choco");
		if(figPadre.estado!=4 || figPadre.estado!=3){
			figPadre.estado = 3;
			StartCoroutine("Asentar");
		}
	}

	private void OnTriggerExit2D(){
		if(figPadre.estado!=4)
			figPadre.estado = 2;
	}

	private void OnTriggerStay2D(){
		if(figPadre.estado==2){
			figPadre.estado = 3;
			StartCoroutine("Asentar");
		}
	}

	private IEnumerator Asentar(){

		Vector3 pos; 

		yield return new WaitForSeconds(0.5f);

		if(figPadre.estado == 3){
			figPadre.estado = 4;
			Vector2 aux = figPadre.rigidbody2D.velocity;
			aux.x = 0;
			figPadre.rigidbody2D.velocity = aux;
			Control.getInstancia.crearFigura();
			pos = figPadre.transform.position;

			if(pos.y<0){
				pos.y = Mathf.Floor(Mathf.Abs(pos.y*4))/4;
				pos.y *= -1;
			}
			else{
				pos.y = Mathf.Round(Mathf.Abs(pos.y*4))/4;
			}
			

			pos.x = Mathf.Round((pos.x - 0.25f)*2) /2 + 0.25f;

			figPadre.transform.position = pos;
			figPadre.rigidbody2D.isKinematic = true;
		}
	}
}
