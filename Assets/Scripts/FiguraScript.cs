using UnityEngine;
using System.Collections;

public class FiguraScript : MonoBehaviour {

	public const int CONGELADO = 1;
	public const int MOVIENDOSE = 2;

	public float velocidad;
	private Vector2 vector_speed;
	private Vector2 fuerza;
	private int estado;

	// Use this for initialization
	void Start () {
		fuerza = new Vector2(-2000,0);		
		velocidad *= -1;
		vector_speed = new Vector2(0, velocidad);
		rigidbody2D.velocity = vector_speed;
		estado = MOVIENDOSE;

	}
	
	// Update is called once per frame
	void Update () {

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

		}else{
			if( estado == MOVIENDOSE && Input.GetAxis("Horizontal")!=0){
				if(Input.GetAxis("Horizontal")<0){
					Debug.Log("izquierda");
					rigidbody2D.velocity = new Vector2(-3,rigidbody2D.velocity.y);
				}else if(Input.GetAxis("Horizontal")>0){
					Debug.Log("derecha");
					rigidbody2D.velocity = new Vector2(3,rigidbody2D.velocity.y);
				}
			}
		}


	}



}
