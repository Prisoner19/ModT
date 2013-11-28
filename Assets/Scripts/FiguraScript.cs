using UnityEngine;
using System.Collections;

public class FiguraScript : MonoBehaviour {
	
	public const int CONGELADO = 1;
	public const int MOVIENDOSE = 2;
	public const int TEMPORAL = 3;
	public const int ASENTADO = 4;
	
	public float velocidad;
	public bool aceleracion;
	private Vector2 vector_speed;
	private Vector2 vector_acelerado;
	private Vector3 pos;

	public int estado;
	public int num_bloques;


	// Use this for initialization
	void Start () {
		pos = transform.position;
		velocidad *= -1;
		vector_speed = new Vector2(0, velocidad);
		vector_acelerado = new Vector2(0,velocidad*3);
		rigidbody2D.velocity = vector_speed;
		estado = MOVIENDOSE;
		aceleracion = false;
		num_bloques = 4;
	}
	
	// Update is called once per frame
	void Update () {
		if(estado != 4){
			pos = transform.position;
			if(Input.GetButtonDown("Jump")){
				if(!Control.getInstancia.stop){
					rigidbody2D.velocity = Vector2.zero;
					Control.getInstancia.txt_freeze.guiText.text = "Freeze time!";
					estado = CONGELADO;
					pos.x = Mathf.Round((transform.position.x - 0.25f)*2)/2+0.25f;
					pos.y = (((Mathf.Floor(((pos.y*4)+1)/2))*2)-1)/4;
					transform.position = pos;
				}
				else{
					rigidbody2D.velocity = vector_speed;
					Control.getInstancia.txt_freeze.guiText.text = "";
					estado = MOVIENDOSE;
				}
				Control.getInstancia.stop = !Control.getInstancia.stop;
				
			}
			else{
				if( estado == MOVIENDOSE || estado == TEMPORAL){
					
					if(Input.GetKey("a") || Input.GetKey("left")){
						if(aceleracion)
							rigidbody2D.velocity = new Vector2(-6,vector_acelerado.y);
						else
							rigidbody2D.velocity = new Vector2(-3,vector_speed.y);
						if(estado!=TEMPORAL)
							estado = MOVIENDOSE;

					}
					else if(Input.GetKeyUp("a") || Input.GetKeyUp("left")){
						pos.x = Mathf.Round((transform.position.x - 0.25f)*2) /2 + 0.25f;
						transform.position = pos;
						if(aceleracion)
							rigidbody2D.velocity = vector_acelerado;
						else
							rigidbody2D.velocity = vector_speed;
						
					}
					
					if(Input.GetKey("d") || Input.GetKey("right")){
						if(aceleracion)
							rigidbody2D.velocity = new Vector2(6,vector_acelerado.y);
						else
							rigidbody2D.velocity = new Vector2(3,vector_speed.y);
						if(estado!=TEMPORAL)
							estado = MOVIENDOSE;
			
					}
					else if(Input.GetKeyUp("d") || Input.GetKeyUp("right")){
						pos.x = Mathf.Round((transform.position.x - 0.25f)*2)/2+0.25f;
						transform.position = pos;
						if(aceleracion)
							rigidbody2D.velocity = vector_acelerado;
						else
							rigidbody2D.velocity = vector_speed;
					}

					if(Input.GetKeyDown("s") || Input.GetKeyDown("down")){
						rigidbody2D.velocity = vector_acelerado;
						aceleracion = true;
					}
					else if(Input.GetKeyUp("s") || Input.GetKeyUp("down")){
						rigidbody2D.velocity = vector_speed;
						aceleracion = false;
					}
				}
			}
		}
	}

}
