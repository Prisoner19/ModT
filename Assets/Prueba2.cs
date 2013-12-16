using UnityEngine;
using System.Collections;

public class Prueba2 : MonoBehaviour {

	
	public Camera myCam;
	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown(){
		Debug.Log("asd");
	}

	
	void Update()
	{
		transform.parent = GameObject.Find("Padre").transform;
	}
}
