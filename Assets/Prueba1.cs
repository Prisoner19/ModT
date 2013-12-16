using UnityEngine;
using System.Collections;

public class Prueba1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("Jump")){
			Destroy(gameObject.GetComponent("Rigidbody2D"));
			rigidbody2D.fixedAngle =  true;
			rigidbody2D.gravityScale = 0;
		}
	
	}
}
