using UnityEngine;
using System.Collections;

public class FiguraScript : MonoBehaviour {

	public float velocidad;
	private Vector2 vector_speed;
	private Vector2 fuerza;

	// Use this for initialization
	void Start () {
		fuerza = new Vector2(-2000,0);		
		velocidad *= -1;
		vector_speed = new Vector2(0, velocidad);
		rigidbody2D.velocity = vector_speed;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Jump")){
			if(!Control.getInstancia.stop){
				rigidbody2D.velocity = Vector2.zero;
				Control.getInstancia.txt_freeze.guiText.text = "Freeze time!";
			}
			else{
				rigidbody2D.velocity = vector_speed;
				Control.getInstancia.txt_freeze.guiText.text = "";
			}
			Control.getInstancia.stop = !Control.getInstancia.stop;
		}
	}

}
