using UnityEngine;
using System.Collections;

public class FiguraScript : MonoBehaviour {

	public const int CONGELADO = 1;
	public const int MOVIENDOSE = 2;

	public float velocidad;
	public bool asentado;
	private Vector2 vector_speed;
	private Vector3 pos;
	private int estado;

	// Use this for initialization
	void Start () {
		Control.figuraActiva = this;
		pos = transform.position;
		velocidad *= -1;
		vector_speed = new Vector2(0, velocidad);
		rigidbody2D.velocity = vector_speed;
		estado = MOVIENDOSE;
		asentado = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!asentado){
			pos = transform.position;
			if(Input.GetButtonDown("Jump")){
				if(!Control.getInstancia.stop){
					rigidbody2D.velocity = Vector2.zero;
					Control.getInstancia.txt_freeze.guiText.text = "Freeze time!";
					estado = CONGELADO;
				}
				else{
					rigidbody2D.velocity = vector_speed;
					Control.getInstancia.txt_freeze.guiText.text = "";
					estado = MOVIENDOSE;
				}
				Control.getInstancia.stop = !Control.getInstancia.stop;

			}
			else{
				if( estado == MOVIENDOSE ){

					if(Input.GetKeyDown("a") || Input.GetKeyDown("left")){
						rigidbody2D.velocity = new Vector2(-3,rigidbody2D.velocity.y);
					}
					else if(Input.GetKeyUp("a") || Input.GetKeyUp("left")){
						pos.x = Mathf.Round((transform.position.x - 0.25f)*2) /2 + 0.25f;
						Debug.Log (pos.x+ " / "+ transform.position.x);
						transform.position = pos;
						rigidbody2D.velocity = vector_speed;

					}

					if(Input.GetKeyDown("d") || Input.GetKeyDown("right")){
						rigidbody2D.velocity = new Vector2(3,rigidbody2D.velocity.y);
					}
					else if(Input.GetKeyUp("d") || Input.GetKeyUp("right")){
						pos.x = Mathf.Round((transform.position.x - 0.25f)*2)/2+0.25f;
						Debug.Log (pos.x+ " / "+ transform.position.x);
						transform.position = pos;
						rigidbody2D.velocity = vector_speed;
					}
				}
			}
		}
	}

	private void OnCollisionEnter2D(){
		//Debug.Log ("Choco");
	}


}
