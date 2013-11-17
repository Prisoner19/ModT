﻿using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	private bool activo=true;
	public bool stop=false;
	public float timer;

	public GUIText txt_freeze;
	public GUIText txt_timer;

	private static Control instancia; 

	private void Awake(){
		instancia = this;	
	}

	// Use this for initialization
	void Start() {
		timer = 60.0f;
		txt_freeze.guiText.text = "";
		crearFigura();
	}
	
	// Update is called once per frame
	void Update() {
	
		if(timer>=0){
			timer -= Time.deltaTime;
			txt_timer.guiText.text = timer.ToString("F1");
		}
	}

	public static Control getInstancia{
		get{
			return instancia;	
		}
	}

	public bool estaActivo{
		get{
			return activo;	
		}
		set{
			activo=value;	
		}
	}

	public void crearFigura(){
		
		Vector3 posInicio = new Vector3(20,360,1);
		
		int rand_fig = UnityEngine.Random.Range (1,6);

		Debug.Log("Prefabs/Figura"+ rand_fig);
		Instantiate(Resources.Load("Prefabs/Figura"+ rand_fig), posInicio, transform.rotation);
		
	}
}